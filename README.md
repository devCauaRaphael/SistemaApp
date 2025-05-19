CRUD de Controle de Produtos e Funcionários

Projeto desenvolvido com foco em aprimorar as técnicas no ecossistema .NET, utilizando o padrão ASP.NET Core MVC e integração com banco de dados MySQL. A aplicação implementa um CRUD completo para gerenciar produtos e funcionários, com uma interface moderna graças ao uso de Bootstrap e CSS. Ideal para consolidar conhecimentos em desenvolvimento web com C#.

✅ Como rodar o projeto
Clone o repositório para sua máquina:
Copiar código
git clone https://github.com/devCauaRaphael/CrudApplication

Abra o arquivo script no MySQL

Crie o banco de dados no MySQL

Abra o projeto no Visual Studio.

Configure a string de conexão com o MySQL no appsettings.json.

Rode o projeto pelo Visual Studio (F5 ou botão "Iniciar").

🗂️ Estrutura de pastas do projeto
bash
Copiar código
/SeuProjeto
│
├── Controllers/           # Controladores MVC (ProdutoController, FuncionarioController)
├── Models/                # Modelos das entidades
├── Views/                 # Páginas da aplicação
│   ├── Produto/
│   └── Funcionario/
├── wwwroot/               # Arquivos estáticos (CSS, JS, imagens)
│   ├── css/
│   └── lib/               # Bootstrap e outras libs           
├── appsettings.json       # Configurações do projeto (incluindo MySQL)
└── Program.cs             # Arquivo de inicialização
🧰 Tecnologias utilizadas
C# com ASP.NET Core MVC: estrutura principal do projeto e lógica de CRUD.


MySQL: banco de dados relacional utilizado para armazenar produtos e funcionários.

Bootstrap: framework para responsividade e componentes visuais.

CSS: personalizações visuais adicionais.

📌 O que foi desenvolvido até agora
CRUD completo para:

Produtos (nome, descrição, preço, quantodade)

Funcionários (nome, senha, email)

Validação de formulários.

Interface responsiva com Bootstrap.

Conexão estável com banco MySQL.

🚧 O que falta desenvolver
Autenticação e controle de acesso por tipo de usuário.

Dashboard com gráficos e estatísticas.

Busca com filtros avançados.

Paginação e ordenação nas listagens.

Criptografia de senha

Adicionar novas tabelas e novos campos nas tabelas já existentes.

📞 Como entrar em contato comigo
📱 Telefone / WhatsApp: (11) 96918-7486

💼 LinkedIn: www.linkedin.com/in/devcauaraphael

📸 Instagram: @cauawlrd
