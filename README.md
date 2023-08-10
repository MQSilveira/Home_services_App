# PI-SENAC - UMA MÃO LAVA A OUTRA

Este é um projeto de um sistema de gerenciamento de empregados e empregadores que permite a contratação de serviços domésticos, manutenção doméstica e pintura. O sistema é projetado para lidar com entidades como Empregados e Empregadores, cada uma com suas características específicas. Além disso, existem regras de negócio que controlam as permissões e visibilidade dos usuários, bem como requisitos não funcionais que garantem a segurança e integridade dos dados.

## Entidades

### Empregado

O Empregado representa um indivíduo que oferece serviços domésticos, manutenção doméstica ou pintura. Ele possui as seguintes características:

- Nome
- Email
- Senha
- CPF ou CNPJ
- Endereço
- Habilidades (serviços domésticos, manutenção doméstica, pintura)
- Valor por habilidade
- Ativo/Inativo
- Nível (0)
- Criado em
- Alterado em
- Alterado por

### Empregador

O Empregador representa um indivíduo que contrata empregados para realizar serviços domésticos, manutenção doméstica ou pintura. Ele possui as seguintes características:

- Nome
- Email
- Senha
- CPF ou CNPJ
- Endereço
- Habilidade contratada
- Valor total contratado
- Ativo/Inativo
- Nível (1)
- Criado em
- Alterado em
- Alterado por

## Regras de Negócio

- Nível: Existem três níveis - empregado (0), empregador (1) e admin (2).
- Conta Única: Um usuário só pode criar uma conta com um determinado email se for empregado ou empregador.
- Listar empregadores: Se o nível for 0, é possível listar empregador(es).
- Listar empregados: Se o nível for 1, é possível listar empregado(s).
- Listar empregadores e empregados: Se o nível for 2, é possível listar empregado(s) e empregador(es).
- Visibilidade para empregador e empregado: Se o empregado estiver ativo (ativo = 1), ele será visível para empregador; caso contrário (ativo = 0), será oculto e vice-versa.
- Valor Inicial Ativo/Inativo: Toda vez que um empregado ou empregador for criado, o status começa com o valor 1 para ativo/inativo.
- Campos de Auditoria: Os campos "Alterado em" e "Alterado por" começam como null.
- Habilidades Iniciais do Empregado: As habilidades do empregado iniciam como null.
- Valor Inicial do Empregado: O valor do empregado inicia como null.

## Registro de Empregado

O aplicativo permite que os empregados se registrem fornecendo informações como nome, email, senha, CPF ou CNPJ, endereço e habilidades. O sistema realiza as seguintes validações:

- Garante que todos os campos obrigatórios sejam preenchidos.
- Verifica se o email fornecido já está sendo usado por outra conta.

Os empregados devem selecionar suas habilidades a partir das opções disponíveis, como serviços domésticos, manutenção doméstica e pintura.

## Registro de Empregador

O aplicativo permite que os empregadores se registrem fornecendo informações como nome, email, senha, CPF ou CNPJ e endereço. O sistema realiza as seguintes validações:

- Garante que todos os campos obrigatórios sejam preenchidos.
- Verifica se o email fornecido já está sendo usado por outra conta.

## Login

O aplicativo possui um sistema de login que permite aos usuários autenticarem-se como empregados ou empregadores. O usuário deve selecionar a opção correta para indicar se é um empregado ou empregador.

## Listagem de Usuários e Clientes

- Se o usuário estiver autenticado como um empregado, o aplicativo fornece uma lista de outros usuários (empregados) registrados no sistema.
- Se o usuário estiver autenticado como um empregador, o aplicativo fornece uma lista de clientes (empregadores) registrados no sistema.

## Visibilidade do Status

- O aplicativo mostra o status ativo ou inativo de cada usuário.
- Os usuários ativos são visíveis para outros usuários no sistema, enquanto os inativos são ocultados.

## Requisitos Não Funcionais

- Senha Forte: A senha deve ter no mínimo 8 caracteres.
- Verificação de Email: O sistema verifica se o email já existe antes de prosseguir.
- Campos Obrigatórios: Todos os campos são obrigatórios.
- Restrição de Seleção de Habilidades: Se as habilidades forem 0, 1 ou 2, o usuário não pode selecionar "todos".
- Valor por Habilidade: Se o checkbox for marcado, o usuário deve preencher o campo de valor.
- Valores Não Nulos: Os campos de valores não podem ser nulos.

---

Este é um resumo das principais funcionalidades, entidades e regras de negócio do sistema. Sinta-se à vontade para adicionar mais informações e detalhes específicos de implementação ao seu README, de acordo com as necessidades do seu projeto.
