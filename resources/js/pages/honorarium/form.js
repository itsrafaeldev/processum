const errorProcessNumber = document.getElementById("error-process-number");
const errorDueDate = document.getElementById("error-due-date");
const errorClient_ID = document.getElementById("error-client_id");
const errorAmount = document.getElementById("error-legalFee-amount");
const errorQuantityInstallment = document.getElementById("error-quantity-installment");

let input_process_number_id = document.getElementById("process_number_id");
let input_due_date = document.getElementById("due_date");
let input_select_client_id = document.getElementById("client_id");
let input_note = document.getElementById("note");
let input_amount = document.getElementById("amount");
let input_quantity_installment = document.getElementById("quantity_installment");

const legalFee = JSON.parse(document.getElementById("legalFee").dataset.legalFee);
const installmentsLegalFee = JSON.parse(document.getElementById('tblInstallmentsLegalFee').dataset.installments || '[]');
const process = JSON.parse(document.getElementById("process_number_id").dataset.process || 'null');

let choicesInstances = {};

const saveButton = document.getElementById("saveButton");
const form = document.getElementById("legalFeeForm");
const enterInstallmentsButton = document.getElementById("enterInstallments");

document.addEventListener("DOMContentLoaded", function () {

    initProcessNumberChoices();
    initClientChoices();
    initTableInstallments(installmentsLegalFee);

    const deleteButton = document.getElementById("deleteButton");
    const due_date_container = document.getElementById('due_date_container')

    let clientChoices = getChoicesInstance('#client_id');
    clientChoices.disable();
    setInstance(clientChoices, '#client_id');


    let processNumberChoices = getChoicesInstance('#process_number_id');
    setInstance(processNumberChoices, '#process_number_id');


    if (legalFee.id_public === 0) {
        deleteButton.classList.add("disabled");
        enterInstallmentsButton.style.display = "none";

    }

    if (legalFee.id_public !== 0) {
        deleteButton.classList.remove("disabled");
        document.querySelectorAll('.form-control').forEach(input => {
            input.disabled = true;
        });
        clientChoices.input.element.placeholder = '';

        processNumberChoices.disable();
        saveButton.style.display = "none";
        due_date_container.style.display = "none";

    }
});

saveButton.addEventListener("click", async function (e) {
    e.preventDefault();

    // Pegar valores
    const value_process_number_id = input_process_number_id.value;
    const value_due_date = input_due_date.value;
    const value_client_id = Array.from(input_select_client_id.selectedOptions).map(option => option.value);
    const value_note = input_note.value;
    const value_amount = unmaskMoney(input_amount.value);
    const value_quantity_installment = input_quantity_installment.value;

    // Determinar rota e método
    const route =
        legalFee.id_public != 0
            ? "/legal-fee/update/" + legalFee.id_public
            : "/legal-fee/save";
    const method = legalFee.id_public != 0 ? "PUT" : "POST";

    const response = await fetch(route, {
        method: method,
        headers: {
            "Content-Type": "application/json",
            "X-CSRF-TOKEN": document
                .querySelector('meta[name="csrf-token"]')
                .getAttribute("content"),
        },
        body: JSON.stringify({
            id_public: legalFee.id_public,
            process_number_id: value_process_number_id,
            due_date:  legalFee.id_public != 0 ? new Date().toISOString().slice(0, 10) : value_due_date,
            client_id: value_client_id,
            note: value_note,
            amount: parseFloat(value_amount),
            quantity_installment: value_quantity_installment,
        }),
    });

    const res = await response.json();

    if (!res.success) {

        if(res.warnings.length > 0){
            res.warnings.forEach((warning) => {
                toast.warning("Atenção!", warning);
            });
            return;
        }

        res.errors.forEach((erro) => {
            toast.error("Erro!", erro);
        });
        return;
    }

    window.location.href = "/legal-fee";
});

document
    .getElementById("deleteButton")
    .addEventListener("click", async function (e) {
        e.preventDefault();

        if (!confirm("Tem certeza que deseja deletar este honorário?")) {
            return;
        }

        const idPublic = this.dataset.id_public;
        const route = "/legal-fee/delete/" + idPublic; // ajuste conforme sua rota
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
        if (res.status != 200 || res.status != 204) {
            toast.error('Erro!', res.error)
            return;
        }
        window.location.href = "/legal-fee";

    });


function initProcessNumberChoices() {
initChoices({
    selector: '#process_number_id',
    url: '/judicial-process/search-process',
    fieldId: 'id_public',
    fieldText: 'process_number',
    placeholder: 'Selecione um processo...',
    multiple: false,
    selected: document.querySelector('#process_number_id').dataset.process ?
        JSON.parse(document.querySelector('#process_number_id').dataset.process) : [],
    maskActived: true,
    mask: "0000000-00.0000.0.00.0000"
});
}

function initClientChoices() {
    initChoices({
    selector: '#client_id',
    url: '/client/search-clients',
    fieldId: 'id_public',
    fieldText: 'name',
    placeholder: 'Selecione um cliente...',
    multiple: true,
    selected: document.querySelector('#client_id').dataset.selectedClients ?
        JSON.parse(document.querySelector('#client_id').dataset.selectedClients) : [],
    maskActived: false,
    removeItemButton: false,
});
}


function  initTableInstallments(installmentsLegalFee) {
    const gridElement = document.getElementById('tblInstallmentsLegalFee');

        const gridOptions = {
            rowData: installmentsLegalFee,
            defaultColDef: {
                sortable: true,
                filter: true,
                resizable: true
            },
            pagination: true,
            paginationPageSize: 10,
            paginationPageSizeSelector: [10, 20, 50, 100],
            domLayout: 'autoHeight',
            localeText: window.AG_GRID_LOCALE_BR,
            columnDefs: [
                {
                    headerName: 'Cliente',
                    flex: 1,
                    valueGetter: params => params.data.client?.name || ''
                },

                { field: 'current_installment', headerName: 'Parcela', flex: 1 },
                {
                    field: 'value_installment',
                    headerName: 'Valor',
                    flex: 1,
                    valueFormatter: params => {
                        return new Intl.NumberFormat('pt-BR', {
                            style: 'currency',
                            currency: 'BRL'
                        }).format(params.value);
                    }
                },
                {
                    field: 'due_date',
                    headerName: 'Vencimento',
                    flex: 1,
                    valueFormatter: params => {
                        const [ano, mes, dia] = params.value.split("-");
                        return `${dia}/${mes}/${ano}`;                    }
                },
                { headerName: 'Status', flex: 1, valueGetter: params => params.data.status_payment?.description || ''  },
            ],
        };

        createGrid(gridElement, gridOptions);
};

document.getElementById('amount').addEventListener('input', function(e) {
    let value = e.target.value.replace(/\D/g, ''); // remove tudo que não for número

    // garante ao menos dois dígitos
    if (value.length < 3) {
        value = value.padStart(3, '0');
    }

    // formata de trás pra frente
    const centavos = value.slice(-2);
    const inteiros = value.slice(0, -2);
    const formatado ='R$ ' + parseInt(inteiros).toLocaleString('pt-BR') + ',' + centavos;

    e.target.value = formatado.replace(/^NaN,/, '0,');
});

enterInstallmentsButton.addEventListener('click', (event)=>{
    event.preventDefault();
    input_quantity_installment.disabled = false;
    saveButton.style.display = "";
    enterInstallmentsButton.style.display = "none";
})

input_process_number_id.addEventListener('change', () => {
    const selected = choicesInstances['#process_number_id'].getValue();
    const clients = selected.customProperties.clients;

    updateClientsSelect(clients, choicesInstances['#client_id']);

});

function setInstance(instance, selector) {
    choicesInstances[selector] = instance;
}

function updateClientsSelect(clientsArray, instanceClientChoices) {

    const clientChoices = instanceClientChoices;
    instanceClientChoices.input.element.placeholder = '';

    // limpar tudo
    clientChoices.clearChoices();
    clientChoices.clearStore();
    clientChoices.removeActiveItems();

    // adicionar os novos clientes
    clientChoices.setChoices(
        clientsArray.map(c => ({
            value: c.id_public,
            label: c.name,
            selected: true
        })),
        'value',
        'label',
        true
    );
}
