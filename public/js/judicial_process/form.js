
const errorNature = document.getElementById("error-nature");
const errorJudicial = document.getElementById("error-judicial");
const errorProcessNumber = document.getElementById("error-process-number");
const errorInitialDate = document.getElementById("error-initial-date");
const errorClient_ID = document.getElementById("error-client_id");
const errorRespondent = document.getElementById("error-respondent");

let input_process_number = document.getElementById("process_number");
let input_initial_date = document.getElementById("initial_date");
let input_select_client_id = document.getElementById("client_id");
let input_respondent = document.getElementById("respondent");
let input_select_nature_action = document.getElementById(
    "select_nature_action"
);
let input_select_judicial_action = document.getElementById(
    "select_judicial_action"
);
let input_is_archived = document.getElementById("is_archived");
let input_description = document.getElementById("description");

const process = JSON.parse(document.getElementById("process").dataset.process);

// Preencher select de Natuereza da açao e a açao judicial
document.addEventListener("DOMContentLoaded", function () {

    getClientsChoices();

    // Botão de delete
    const deleteButton = document.getElementById("deleteButton");
    if (process.id_public === 0) {
        deleteButton.classList.add("disabled");
    }

    // Pegar actions do data-attribute
    const actions = JSON.parse(input_select_judicial_action.dataset.actions);

    // Ao mudar a natureza
    input_select_nature_action.addEventListener("change", function () {
        const selectedNatureId = parseInt(this.value);

        // Validar natureza
        validateNature();

        if (!selectedNatureId) {
            return;
        }

        // Limpar opções antigas
        input_select_judicial_action.innerHTML =
            '<option value="0">Selecione uma ação...</option>';

        // Filtrar actions pelo nature_action_id
        const filteredActions = actions.filter(
            (a) => a.nature_action_id === selectedNatureId
        );

        // Popular select de ações
        filteredActions.forEach((action) => {
            const option = document.createElement("option");
            option.value = action.id;
            option.textContent = action.judicial_action;
            input_select_judicial_action.appendChild(option);
        });
    });

    // Se processo já existe, pré-seleciona os selects
    if (process.id_public !== 0) {
        input_select_nature_action.value = process.nature_action_id;

        // Disparar change manual para popular select_judicial_action
        input_select_nature_action.dispatchEvent(new Event("change"));
        select_judicial_action.value = process.judicial_action_id;
        deleteButton.classList.remove("disabled");
    }
});

const saveButton = document.getElementById("saveButton");
const form = document.getElementById("processForm");

saveButton.addEventListener("click", async function (e) {
    e.preventDefault();
    // Limpar classes de validação
    form.querySelectorAll("input, select, textarea").forEach((field) => {
        field.classList.remove("is-invalid", "is-valid");
    });

    // Pegar valores
    const value_process_number = getUnmaskedValue(input_process_number); //Remove a mascara do input e retornando o valor
    const value_initial_date = input_initial_date.value;
    const value_client_id = Array.from(input_select_client_id.selectedOptions).map(option => option.value);
    const value_respondent = input_respondent.value;
    const value_select_nature_action = input_select_nature_action.value;
    const value_select_judicial_action = input_select_judicial_action.value;
    const value_is_archived = input_is_archived.checked;
    const value_description = input_description.value;

    // Determinar rota e método
    const route =
        process.id_public != 0
            ? "/judicial-process/update/" + process.id_public
            : "/judicial-process/save";
    const method = process.id_public != 0 ? "PUT" : "POST";

    validateForm();
    const response = await fetch(route, {
        method: method,
        headers: {
            "Content-Type": "application/json",
            "X-CSRF-TOKEN": document
                .querySelector('meta[name="csrf-token"]')
                .getAttribute("content"),
        },
        body: JSON.stringify({
            id_public: process.id_public,
            process_number: value_process_number,
            initial_date: value_initial_date,
            client_id: value_client_id,
            respondent: value_respondent,
            nature_action_id: value_select_nature_action,
            judicial_action_id: value_select_judicial_action,
            is_archived: value_is_archived,
            description: value_description,
        }),
    });

    const res = await response.json();

    if (!res.success) {
        res.errors.forEach((erro) => {
            toast.error("Erro!", erro);
        });
        return;
    }
    window.location.href = "/judicial-process";
});

document
    .getElementById("deleteButton")
    .addEventListener("click", async function (e) {
        e.preventDefault();

        if (!confirm("Tem certeza que deseja deletar este processo?")) {
            return;
        }

        const idPublic = this.dataset.id_public;
        const route = "/judicial-process/delete/" + idPublic; // ajuste conforme sua rota
        const token = document
            .querySelector('meta[name="csrf-token"]')
            .getAttribute("content");


        const response = await fetch(route, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
                "X-CSRF-TOKEN": token,
            },
        });

        const res = await response.json();
        if (res.status != 200) {
            toast.error('Erro!', res.error)
            return;
        }
        window.location.href = "/judicial-process";

    });

function validateForm() {
    validateProcessInput();
    validateInitialDate();
    validateClient_ID();
    validateRespondent();
    validateNature();
    validateNature();
    validateActionJudicial();
    validateDescription();
}

function validateProcessInput() {
    const rawValue = input_process_number.value.replace(/\D/g, "");

    // Limpa validações anteriores
    errorProcessNumber.style.display = "none";
    errorProcessNumber.textContent = "";
    input_process_number.classList.remove("border-danger");

    if (!rawValue || rawValue === "") {
        errorProcessNumber.textContent = "Preencha este campo!";
        errorProcessNumber.style.display = "block";
        input_process_number.classList.add("border-danger");
        return false;
    }
    if (rawValue.length < 20) {
        const message = `Limite mínimo não atingido! ${rawValue.length} caractere(s) até o momento.`;
        errorProcessNumber.textContent = message;
        errorProcessNumber.style.display = "block";
        input_process_number.classList.add("border-danger");
        return false;
    }
    return true;
}

function validateNature() {
    const value = select_nature_action.value;
    input_process_number.classList.remove("border-danger");

    if (!value || value === "") {
        const message = "Selecione uma natureza da ação!";

        errorNature.textContent = message;
        errorNature.style.display = "block";
        input_process_number.classList.add("border-danger");
        return false;
    } else {
        errorNature.style.display = "none";
        return true;
    }
}

function validateActionJudicial() {
    const value = select_judicial_action.value;
    select_judicial_action.classList.remove("border-danger");

    if (!value || value === "" || value === "0") {
        const message = "Selecione uma ação judicial!";

        errorJudicial.textContent = message;
        errorJudicial.style.display = "block";
        select_judicial_action.classList.add("border-danger");
        return false;
    } else {
        errorJudicial.style.display = "none";
        return true;
    }
}

function validateInitialDate() {
    initial_date.style.color = "black";
    input_initial_date.classList.remove("border-danger");

    const dateParts = input_initial_date.value.split("-");
    const afterDate = new Date(dateParts[0], dateParts[1] - 1, dateParts[2]);
    const today = new Date();

    afterDate.setHours(0, 0, 0, 0);
    today.setHours(0, 0, 0, 0);

    if (afterDate > today) {
        initial_date.style.color = "red";
        input_initial_date.classList.add("border-danger");

    }

    const value = initial_date.value;
    if (!value || value === "" || value === "0") {
        let message = "Selecione a data de inicio do processo!";
        errorInitialDate.textContent = message;
        errorInitialDate.style.display = "block";
        input_initial_date.classList.add("border-danger");
        return false;
    } else {
        errorInitialDate.style.display = "none";
        return true;
    }
}




function validateClient_ID() {
    const value = input_select_client_id.value;

    const choicesContainer = choices.containerOuter.element;
    const choicesSelection = choices.containerInner.element;


    input_select_client_id.classList.remove("border-danger");

    if (!value || value === "") {
        const message = "Informe o nome do Reclamante!";
        errorClient_ID.textContent = message;
        errorClient_ID.style.display = "block";
        input_select_client_id.classList.add("border-danger");
        choicesContainer.addClass('border border-danger rounded');
        choicesSelection.css({
            'border': 'none',
            'box-shadow': 'none'
        });

        return false;
    } else {
        errorClient_ID.style.display = "none";
        return true;
    }
}

function validateRespondent() {
    const value = input_respondent.value;
    input_respondent.classList.remove("border-danger");

    if (!value || value === "") {
        const message = "Informe o nome do Reclamado!";

        input_respondent.classList.add("border-danger");
        errorRespondent.textContent = message;
        errorRespondent.style.display = "block";
        return false;
    } else {
        errorRespondent.style.display = "none";
        return true;
    }
}

function validateDescription() {
    const maxChars = 500;
    const charCount = document.getElementById("charCount");
    let currentLength = input_description.value.length;
    input_description.classList.remove("border-danger");

    charCount.style.color = "black";

    if (currentLength >= maxChars) {
        input_description.value = input_description.value.substring(0, maxChars);
        currentLength = maxChars;
        charCount.style.color = "red";
        input_description.classList.add("form-control", "border", "border-danger");
    }

    charCount.textContent = "Caracteres: " + currentLength + "/" + maxChars;
}

function getClientsChoices() {
    window.initChoices({
        selector: '#client_id',
        url: '/client/search-clients',
        fieldId: 'id_public',
        fieldText: 'name',
        placeholder: 'Selecione ao menos um cliente...',
        multiple: true,
        selected: document.querySelector('#client_id').dataset.selectedClients ?
            JSON.parse(document.querySelector('#client_id').dataset.selectedClients) : [],
        maskActived: false,
    });
}
