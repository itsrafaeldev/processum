import Choices from 'choices.js';

let choicesInstances = {};
async function initChoices(config) {
    const element = document.querySelector(config.selector);

    if (!element) {
        console.error(`Elemento ${config.selector} não encontrado`);
        return;
    }

    if (config.multiple) {
        element.setAttribute('multiple', '');
    }

    // Configuração do Choices.js
    const choices = new Choices(element, {
        placeholder: true,
        placeholderValue: config.placeholder || 'Selecione...',
        searchPlaceholderValue: config.language?.searching || 'Buscar...',
        noResultsText: config.language?.noResults || 'Nenhum resultado encontrado',
        noChoicesText: config.language?.inputTooShort ?
            config.language.inputTooShort({ minimum: config.minimumInputLength || 3 }) :
            `Digite pelo menos ${config.minimumInputLength || 3} caracteres`,
        removeItemButton: config.removeItemButton || false,
        //multiple: config.multiple || false,
        searchEnabled: true,
        searchFloor: config.minimumInputLength || 3,
        shouldSort: false,
        itemSelectText: '',
    });

    let searchTimeout;
    let lastSearchTerm = '';

    // Listener para busca
    element.addEventListener('search', async (event) => {
        const searchTerm = event.detail.value;

        // Limpa timeout anterior
        clearTimeout(searchTimeout);

        // Verifica tamanho mínimo
        if (searchTerm.length < (config.minimumInputLength || 3)) {
            choices.clearChoices();
            return;
        }

        // Evita buscar o mesmo termo
        if (searchTerm === lastSearchTerm) return;
        lastSearchTerm = searchTerm;

        // Delay na busca
        searchTimeout = setTimeout(async () => {
            try {
                const response = await fetch(`${config.url}?q=${encodeURIComponent(searchTerm)}`);
                const data = await response.json();
                // Limpa opções anteriores
                choices.clearChoices();

                // Adiciona novos resultados
                const items = data.map(item => ({
                    value: item[config.fieldId],
                    label: config.maskActived ?
                        maskStringCustomize(item[config.fieldText], config.mask) :
                        item[config.fieldText],
                    customProperties: item // Guarda o item completo se precisar
                }));

                choices.setChoices(items, 'value', 'label', true);
            } catch (error) {
                console.error('Erro ao buscar dados:', error);
            }
        }, config.delay || 300);
    });
    // Adiciona itens pré-selecionados
    const selectedItems = element.dataset.selected ?
        JSON.parse(element.dataset.selected) :
        (config.selected || []);

    if (selectedItems.length > 0) {
        const preSelectedItems = selectedItems.map(item => ({
            value: item[config.fieldId],
            label: config.maskActived ?
                maskStringCustomize(item[config.fieldText], config.mask) :
                item[config.fieldText],
            selected: true
        }));

        choices.setChoices(preSelectedItems, 'value', 'label', false);
        removePlaceholder(choices);

    }



    // window.choices = choices;
    choicesInstances[config.selector] = choices;
    return choices;
}

function getChoicesInstance(selector) {
    return choicesInstances[selector] || null;
}

// helper: remove qualquer placeholder dentro do choices
function removePlaceholder(choices) {
    if (!choices || !choices.containerInner || !choices.containerInner.element) return;
    const placeholders = choices.containerInner.element.querySelectorAll('.choices__placeholder');
    placeholders.forEach(ph => ph.remove());
}


// Expondo a função globalmente
window.initChoices = initChoices;
window.getChoicesInstance = getChoicesInstance;
