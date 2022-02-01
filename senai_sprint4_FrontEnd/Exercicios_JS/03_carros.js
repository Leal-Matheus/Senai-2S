/*
Declare uma variável chamada `isTruthy`, e atribua a ela uma função que recebe
um único parâmetro como argumento. Essa função deve retornar `true` se o
equivalente booleano para o valor passado no argumento for `true`, ou `false`
para o contrário.
*/
var isTruthy = function(param) {
    return param ? true : false;
};

// Invoque a função criada acima, passando todos os tipos de valores `falsy`.
isTruthy('');
isTruthy(0);
isTruthy(null);
isTruthy(false);
isTruthy(NaN);

/*
Invoque a função criada acima passando como parâmetro 10 valores `truthy`.
*/
isTruthy(true);
isTruthy(1);
isTruthy('Matheus');
isTruthy([]);
isTruthy([0,1,2,3,4,5]);
isTruthy({});
isTruthy({'dev': true, 'js': true});
isTruthy(function() {});
isTruthy('abc' + 123);
isTruthy(10 + 16);

/*
Declare uma variável chamada `carro`, atribuindo à ela um objeto com as
seguintes propriedades (os valores devem ser do tipo mostrado abaixo):
- `marca` - String
- `modelo` - String
- `placa` - String
- `ano` - Number
- `cor` - String
- `quantasPortas` - Number
- `assentos` - Number - cinco por padrão
- `quantidadePessoas` - Number - zero por padrão
*/
var carro = new Object()
    carro.marca = 'Honda';
    carro.modelo = 'CRV';
    carro.placa = 'ABC-0123';
    carro.ano = 2018;
    carro.cor = 'preto';
    carro.quantasPortas = 4;
    carro.assentos = 5;
    carro.quantidadePessoas = 0;


/*
Crie um método chamado `mudarCor` que mude a cor do carro conforme a cor
passado por parâmetro.
*/
carro.mudarCor = function(cor) {
    carro.cor = cor;
};

/*
Crie um método chamado `obterCor`, que retorne a cor do carro.
*/
carro.Cor = function() {
    return carro.cor;
}

/*
Crie um método chamado `obterModelo` que retorne o modelo do carro.
*/
carro.Modelo = function() {
    return carro.modelo;
}

/*
Crie um método chamado `obterMarca` que retorne a marca do carro.
*/
carro.Marca = function() {
    return carro.marca;
}

/*
Crie um método chamado `obterMarcaModelo`, que retorne:
"Esse carro é um [MARCA] [MODELO]"
Para retornar os valores de marca e modelo, utilize os métodos criados.
*/
carro.MarcaModelo = function() {
    return 'Esse carro é um ' + carro.Marca() + ' ' + carro.Modelo();
}

/*
Crie um método que irá adicionar pessoas no carro. Esse método terá as
seguintes características:
- Ele deverá receber por parâmetro o número de pessoas entrarão no carro. Esse
número não precisa encher o carro, você poderá acrescentar as pessoas aos
poucos.
- O método deve retornar a frase: "Já temos [X] pessoas no carro!"
- Se o carro já estiver cheio, com todos os assentos já preenchidos, o método
deve retornar a frase: "O carro já está lotado!"
- Se ainda houverem lugares no carro, mas a quantidade de pessoas passadas por
parâmetro for ultrapassar o limite de assentos do carro, então você deve
mostrar quantos assentos ainda podem ser ocupados, com a frase:
"Só cabem mais [QUANTIDADE_DE_PESSOAS_QUE_CABEM] pessoas!"
-q Se couber somente mais uma pessoa, mostrar a palavra "pessoa" no retorno
citado acima, no lugar de "pessoas".
*/
carro.adicionarPessoas = function(numeroDePessoas) {
    var totalDePessoas = (numeroDePessoas) ? carro.quantidadePessoas + numeroDePessoas : 0;

    if (carro.estaCheio(totalDePessoas)) {
        return carro.mensagemCheio();
    }

    if (carro.temAssentosDisponiveis(totalDePessoas)) {
        return carro.mensagemNumeroDeAssentosDisponiveis();
    }

    carro.quantidadePessoas += numeroDePessoas;
    return carro.mensagemTotalDePessoas();
}

carro.estaCheio = function(numeroDePessoas) {
    return (carro.assentos === carro.quantidadePessoas && numeroDePessoas >= carro.assentos);
}

carro.mensagemCheio = function() {
    return 'O carro já está lotado!';
}

carro.temAssentosDisponiveis = function(numeroDePessoas) {
    return numeroDePessoas > carro.assentos;
}

carro.mensagemNumeroDeAssentosDisponiveis = function() {
    var assentosDisponiveis = carro.assentos - carro.quantidadePessoas;
    var textoPessoas = (assentosDisponiveis > 1) ? 'pessoas' : 'pessoa';
    return 'Só cabem mais ' + assentosDisponiveis + ' '+ textoPessoas;
}

carro.mensagemTotalDePessoas = function() {
    return 'Já temos ' + carro.quantidadePessoas + ' pessoas no carro!';
}

/*
Agora vamos verificar algumas informações do carro. Para as respostas abaixo,
utilize sempre o formato de invocação do método (ou chamada da propriedade),
adicionando comentários _inline_ ao lado com o valor retornado, se o método
retornar algum valor.

Qual a cor atual do carro?
*/
console.log(carro.Cor())

// Mude a cor do carro para vermelho.
console.log(carro.mudarCor('amarelo'))

// E agora, qual a cor do carro?
console.log(carro.Cor())

// Mude a cor do carro para verde musgo.
console.log(carro.mudarCor('prata'))

// E agora, qual a cor do carro?
console.log(carro.Cor())

// Qual a marca e modelo do carro?
console.log(carro.MarcaModelo())

// Adicione 2 pessoas no carro.
console.log(carro.adicionarPessoas(2))

// Adicione mais 4 pessoas no carro.
console.log(carro.adicionarPessoas(4))

// Faça o carro encher.
console.log(carro.adicionarPessoas(3))

// Tire 4 pessoas do carro.
console.log(carro.adicionarPessoas(-4))

// Adicione 10 pessoas no carro.
console.log(carro.adicionarPessoas(10))

// Quantas pessoas temos no carro?
console.log(carro.quantidadePessoas)