const errorName = document.getElementById("error-name");
const errorCPF = document.getElementById("error-cpf");
const errorEmail = document.getElementById("error-email");
const errorAddress = document.getElementById("error-address");
const errorMobile = document.getElementById("error-mobile");
const errorPhone = document.getElementById("error-phone");

let input_name = document.getElementById("name");
let input_cpf = document.getElementById("cpf");
let input_email = document.getElementById("email");
let input_address = document.getElementById("address");
let input_mobile = document.getElementById("mobile");
let input_phone = document.getElementById("phone");

localStorage.setItem('type_entity', 'PF');

// const clientInput = document.getElementById("client");
const client = JSON.parse(document.getElementById("client").dataset.client);
// Preencher select de Natuereza da açao e a açao judicial
document.addEventListener("DOMContentLoaded", function () {
    // Botão de delete
    const deleteButton = document.getElementById("deleteButton");
    if (client.id_public === 0) {
        deleteButton.classList.add("disabled");
    }
});

const saveButton = document.getElementById("saveButton");
const form = document.getElementById("clientForm");

saveButton.addEventListener("click", async function (e) {
    e.preventDefault();
    // Limpar classes de validação
    form.querySelectorAll("input, select, textarea").forEach((field) => {
        field.classList.remove("is-invalid", "is-valid");
    });

    // Pegar valores
    const value_name = input_name.value;
    const value_cpf = getUnmaskedValue(input_cpf); //Remove a mascara do input e retornando o valor
    const value_email = input_email.value;
    const value_address = input_address.value;
    const value_mobile = getUnmaskedValue(input_mobile); //Remove a mascara do input e retornando o valor
    const value_phone = getUnmaskedValue(input_phone); //Remove a mascara do input e retornando o valor

    // Determinar rota e método
    const route =
        client.id_public != 0
            ? "/client/pf/update/" + client.id_public
            : "/client/pf/save";
    const method = client.id_public != 0 ? "PUT" : "POST";

    const token = document
        .querySelector('meta[name="csrf-token"]')
        .getAttribute("content");

    validateForm();

    const response = await fetch(route, {
        method: method,
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
            "X-CSRF-TOKEN": token,
        },
        credentials: "same-origin",
        body: JSON.stringify({
            id_public: client.id_public,
            name: value_name,
            cpf: value_cpf,
            email: value_email,
            address: value_address,
            mobile: value_mobile,
            phone: value_phone,
        }),
    });

    const res = await response.json();

    if (!res.success) {
        res.errors.forEach((erro) => {
            toast.error("Erro!", erro);
        });
        return;
    }
    window.location.href = "/client";
});


document
    .getElementById("deleteButton")
    .addEventListener("click", async function (e) {
        e.preventDefault();

        if (!confirm("Tem certeza que deseja deletar este cliente?")) {
            return;
        }


        const idPublic = this.dataset.id_public;
        const route = "/client/pf/delete/" + idPublic; // ajuste conforme sua rota
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
            toast.error("Erro!", res.error);
            return;
        }
        window.location.href = "/client";
    });

function validateForm() {
    validateName();
    validateCPF();
    validateEmail();
    validateAddress();
    validateMobile();
}

const validators = [
    { input: input_name, validate: validateName },
    { input: input_cpf, validate: validateCPF },
    { input: input_email, validate: validateEmail },
    { input: input_address, validate: validateAddress },
    { input: input_mobile, validate: validateMobile },
];

["input", "blur", "invalid"].forEach((event) => {
    validators.forEach(({ input, validate }) => {
        input.addEventListener(event, validate);
    });
});

function validateName() {
    const name = input_name.value;

    // Limpa validações anteriores
    errorName.style.display = "none";
    errorName.textContent = "";
    input_name.classList.remove("border-danger");

    if (!name || name === "") {
        errorName.textContent = "Preencha este campo!";
        errorName.style.display = "block";
        input_name.classList.add("border-danger");
        return false;
    }

    return true;
}

function validateCPF() {
    const value = input_cpf.value.replace(/\D/g, "");
    input_cpf.classList.remove("border-danger");
    errorCPF.style.display = "none";
    // Verificar conteudo
    if (!value || value === "") {
        const message = "Informe um CPF!";
        errorCPF.textContent = message;
        errorCPF.style.display = "block";
        input_cpf.classList.add("border-danger");
        return false;
    }

    //Validar CPF
    // Regra de validacao aqui

    return true;
}

function validateEmail() {
    const value = input_email.value;
    input_email.classList.remove("border-danger");
    errorEmail.style.display = "none";

    if (!value || value === "") {
        const message = "Informe um email!";

        errorEmail.textContent = message;
        errorEmail.style.display = "block";
        input_email.classList.add("border-danger");
        return false;
    }

    // Validação email aqui

    return true;
}
function validateAddress() {
    input_address.style.color = "black";
    input_address.classList.remove("border-danger");
    errorAddress.style.display = "none";

    const value = input_address.value;
    if (!value || value === "" || value === "0") {
        let message = "Informe um endereço!";
        errorAddress.textContent = message;
        errorAddress.style.display = "block";
        input_address.classList.add("border-danger");
        return false;
    }
    return true;
}
function validateMobile() {
    const value = input_mobile.value.replace(/\D/g, "");
    input_mobile.classList.remove("border-danger");
    errorMobile.style.display = "none";

    if (!value || value === "") {
        const message = "Informe um número de Celular!";
        errorMobile.textContent = message;
        errorMobile.style.display = "block";
        input_mobile.classList.add("border-danger");
        return false;
    }
    return true;
}

