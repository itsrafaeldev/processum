export function maskProcessNumber(value: string): string {
  if(value == ''){
    return '';
  }
  let n = value.slice(0, 7); //Número sequencial do processo
  let d = value.slice(7, 9); //Dígito verificador
  let a = value.slice(9, 13); //Ano de ingresso do processo
  let j = value.slice(13, 14); //Órgão do Poder Judiciário
  let t = value.slice(14, 16); //Tribunal de origem
  let u = value.slice(16, 20); // Unidade de origem
  return `${n}-${d}.${a}.${j}.${t}.${u}`;
}

export function maskProcessDataPtBr(value: string): string {

  const unmasked = unMask(value);
  const year = unmasked.slice(0, 4);
  const month = unmasked.slice(4, 6);
  const day = unmasked.slice(6, 8);

  const dataFormatada = `${day}/${month}/${year}`;
  return dataFormatada;
}

export function unMask(value: string): string {
  if (!value) return '';
  return value.replace(/[^a-zA-Z0-9]/g, '');
}
