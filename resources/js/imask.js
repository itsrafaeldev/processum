import IMask from "imask";
window.IMask = IMask;

const maskInstances = new Map();

// Configurações das máscaras
const maskConfigs = {
    // CPF
    maskCPF: {
        mask: "000.000.000-00",
        lazy: false,
    },

    // CNPJ
    maskCNPJ: {
        mask: "00.000.000/0000-00",
        lazy: false,
    },

    // CPF ou CNPJ (dinâmico)
    maskCPFCNPJ: {
        mask: [
            { mask: "000.000.000-00", lazy: false }, // CPF
            { mask: "00.000.000/0000-00", lazy: false }, // CNPJ
        ],
        dispatch: function (appended, dynamicMasked) {
            var number = (dynamicMasked.value + appended).replace(/\D/g, "");
            return number.length > 11
                ? dynamicMasked.compiledMasks[1] // CNPJ
                : dynamicMasked.compiledMasks[0]; // CPF
        },
    },
    // RG
    maskRG: {
        mask: "00.000.000-0",
        lazy: false,
    },

    // CEP
    maskCEP: {
        mask: "00000-000",
        lazy: false,
    },

    // Telefone (celular/fixo)
    maskPhone: {
        mask: [
            { mask: "(00) 0000-0000", lazy: false }, // Telefone fixo
            { mask: "(00) 00000-0000", lazy: false }, // Celular
        ],
        dispatch: function (appended, dynamicMasked) {
            var number = (dynamicMasked.value + appended).replace(/\D/g, "");
            return number.length > 10
                ? dynamicMasked.compiledMasks[1] // CELULAR
                : dynamicMasked.compiledMasks[0]; // FIXO
        },
    },

    // Telefone fixo
    maskFixedPhone: {
        mask: "(00) 0000-0000",
        lazy: false,
    },

    // Celular
    maskMobile: {
        mask: "(00) 00000-0000",
        lazy: false,
    },

    // Data
    maskDate: {
        mask: Date,
        pattern: "d{/}m{/}Y",
        blocks: {
            d: { mask: IMask.MaskedRange, from: 1, to: 31, maxLength: 2 },
            m: { mask: IMask.MaskedRange, from: 1, to: 12, maxLength: 2 },
            Y: { mask: IMask.MaskedRange, from: 1900, to: 2099 },
        },
        format: function (date) {
            let day = date.getDate();
            let month = date.getMonth() + 1;
            let year = date.getFullYear();

            if (day < 10) day = "0" + day;
            if (month < 10) month = "0" + month;

            return [day, month, year].join("/");
        },
        parse: function (str) {
            let parts = str.split("/");
            return new Date(parts[2], parts[1] - 1, parts[0]);
        },
        lazy: false,
    },

    // Hora
    maskTime: {
        mask: "00:00",
        lazy: false,
    },

    // Data e Hora
    maskDateTime: {
        mask: "00/00/0000 00:00",
        lazy: false,
    },

    // Dinheiro (Real)
    // maskMoney: {
    //     mask: "R$ num",
    //     blocks: {
    //         num: {
    //             mask: Number,
    //             thousandsSeparator: ".",
    //             radix: ",",
    //             mapToRadix: ["."], // aceita ponto e vírgula como decimal
    //             min: 0,
    //             max: 99999999999999999999999999999999999999999999,
    //             scale: 2,
    //             normalizeZeros: true,
    //             padFractionalZeros: true,
    //         },
    //     },
    //     lazy: false,
    // },
    maskMoney: {
        mask: "R$ num",
        blocks: {
            num: {
                mask: Number,
                thousandsSeparator: ".",
                radix: ",",
                mapToRadix: ["."],
                min: 0,
                max: 9999999999999999,
                scale: 2,
                normalizeZeros: true,
                padFractionalZeros: true,
            },
        },
        lazy: false,
        // comportamento reverso — digita da direita pra esquerda
        overwrite: true,
        autofix: true,
        dispatch: function (appended, dynamicMasked) {
            // Quando o usuário digita, sempre desloca os números pra esquerda (centavos fixos)
            if (/\d/.test(appended)) {
                const number = dynamicMasked.unmaskedValue + appended;
                const newValue = (parseInt(number) / 100).toFixed(2);
                return dynamicMasked.compiledMasks[0];
            }
            return dynamicMasked;
        },
    },

    // Porcentagem
    maskPercent: {
        mask: "num%",
        blocks: {
            num: {
                mask: Number,
                radix: ",",
                mapToRadix: ["."],
                min: 0,
                max: 100,
                scale: 2,
                normalizeZeros: true,
                padFractionalZeros: false,
            },
        },
        lazy: false,
    },

    // Peso (kg)
    maskWeight: {
        mask: "num kg",
        blocks: {
            num: {
                mask: Number,
                radix: ",",
                mapToRadix: ["."],
                min: 0,
                max: 999,
                scale: 2,
                normalizeZeros: true,
                padFractionalZeros: false,
            },
        },
        lazy: false,
    },

    // RG
    maskRG: {
        mask: "00.000.000-0",
        lazy: false,
    },

    // Placa de Carro (formato antigo e Mercosul)
    maskPlate: {
        mask: [
            { mask: "AAA-0000", lazy: false }, // Formato antigo
            { mask: "AAA0A00", lazy: false }, // Mercosul
        ],
        dispatch: function (appended, dynamicMasked) {
            var value = (dynamicMasked.value + appended).replace(
                /[^A-Za-z0-9]/g,
                ""
            );
            // Se tem letra na 5ª posição, é Mercosul
            return /^[A-Za-z]{3}[0-9][A-Za-z]/.test(value) ? 1 : 0;
        },
    },

    // Apenas números
    maskNumbers: {
        mask: /^\d+$/,
        lazy: false,
    },

    // Apenas letras
    maskLetters: {
        mask: /^[A-Za-zÀ-ÿ\s]+$/,
        lazy: false,
    },

    maskProcessNumber: {
        mask: "0000000-00.0000.0.00.0000",
        lazy: true,
    },
};


// Função para aplicar máscaras automaticamente
function applyMasks() {
    // Para cada configuração de máscara
    Object.keys(maskConfigs).forEach((className) => {
        // Encontra todos os elementos com essa classe
        const elements = document.querySelectorAll(`.${className}`);

        elements.forEach((element) => {
            // Verifica se já tem máscara aplicada
            if (maskInstances.has(element)) {
                return; // Já tem máscara, pula
            }

            // Aplica a máscara
            const maskInstance = IMask(element, maskConfigs[className]);

            // Armazena a instância para controle
            maskInstances.set(element, maskInstance);

            // Adiciona classe visual para indicar que tem máscara
            element.classList.add("masked-input");

        });
    });
}



// Função para remover máscara de um elemento
window.removeMask = function (element) {
    const maskInstance = maskInstances.get(element);
    if (maskInstance) {
        const unmasked = maskInstance.unmaskedValue; // ou maskInstance._unmaskedValue
        maskInstance.destroy();
        maskInstances.delete(element);
        element.classList.remove("masked-input");
        return unmasked; // devolve o valor sem máscara
    }
    return element.value; // fallback se não tinha máscara
};

// Função para obter o valor limpo (sem máscara) de um input
window.getUnmaskedValue = function (element) {
    const maskInstance = maskInstances.get(element);
    if (maskInstance) {
        return maskInstance.unmaskedValue;
    }
    return element.value;
};

// Função para obter o valor com máscara
window.getMaskedValue = function (element) {
    const maskInstance = maskInstances.get(element);
    if (maskInstance) {
        return maskInstance.value;
    }
    return element.value;
};

// Função para validar se o valor está completo
window.isMaskComplete = function (element) {
    const maskInstance = maskInstances.get(element);
    if (maskInstance && typeof maskInstance.masked.isComplete === "function") {
        return maskInstance.masked.isComplete;
    }
    return true; // Se não conseguir verificar, assume como completo
};

// Observer para detectar novos elementos adicionados dinamicamente
const observer = new MutationObserver(function (mutations) {
    mutations.forEach(function (mutation) {
        if (mutation.type === "childList") {
            mutation.addedNodes.forEach(function (node) {
                if (node.nodeType === 1) {
                    // Element node
                    // Aplica máscaras nos novos elementos
                    applyMasks();
                }
            });
        }
    });
});

// Inicia o observer (Configurações)
observer.observe(document.body, {
    childList: true, // Observa adição/remoção de elementos filhos
    subtree: true, // Observa mudanças em TODA a árvore (filhos dos filhos)
});

// Aplica máscaras quando o DOM estiver pronto
document.addEventListener("DOMContentLoaded", function () {
    applyMasks();
});

// Reaplica máscaras após AJAX ou mudanças dinâmicas
window.reapplyMasks = function () {
    applyMasks();
};

// Função para mascarar uma string com uma máscara personalizada
window.maskStringCustomize = function (valor, mascara, opcoes = {}) {
    try {
        // Validações básicas
        if (valor === null || valor === undefined) return "";
        if (!mascara || typeof mascara !== "string") return String(valor);

        const valorString = String(valor);

        // Se a máscara for vazia, retorna o valor original
        if (mascara.trim() === "") return valorString;

        // Cria input temporário
        const inputTemp = document.createElement("input");
        inputTemp.type = "text";
        inputTemp.value = valorString;
        inputTemp.style.position = "absolute";
        inputTemp.style.left = "-9999px"; // Esconde visualmente

        document.body.appendChild(inputTemp);

        // Configurações padrão
        const configPadrao = {
            mask: mascara,
            lazy: false,
            overwrite: true,
            autofix: true,
            ...opcoes,
        };

        // Aplica máscara
        const mask = IMask(inputTemp, configPadrao);

        // Força a atualização
        mask.updateValue();
        const resultado = mask.value;

        // Limpeza
        mask.destroy();
        document.body.removeChild(inputTemp);

        return resultado;
    } catch (error) {
        console.error("Erro ao aplicar máscara:", error);
        return String(valor); // Fallback: retorna valor original
    }
}

window.removeCustomizeMaskNumbers = function (valor) {
    let resultado = valor.replace(/\D+/g, '');
    return resultado;
}

window.unmaskMoney = function (value) {
    if (!value) return null;

    return value
        .toString()
        .replace(/\s/g, '')       // remove espaços
        .replace('R$', '')        // remove o símbolo do real
        .replace(/\./g, '')       // remove pontos de milhar
        .replace(',', '.')        // troca vírgula por ponto (decimal)
        .trim();                  // remove espaços finais
}



