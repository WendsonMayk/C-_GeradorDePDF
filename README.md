# 📧 AppMail

**AppMail** é uma aplicação desenvolvida em **C#** para facilitar o envio de e-mails de forma simples e eficiente. Ele utiliza bibliotecas modernas e um arquivo de configuração `.env` para armazenar informações de autenticação do usuário, como e-mail, senha e configurações de SMTP.

## 🛠 Bibliotecas Utilizadas

O AppMail foi criado utilizando as seguintes bibliotecas:

- **NewtonSoft.Json** para manipulação de arquivos JSON.
- **DotEnv** para carregar variáveis de ambiente de arquivos `.env`.
- **iText7** para geração e manipulação de documentos PDF.

---

## ⚙️ Configuração do App
Antes de executar a aplicação, você precisa editar o arquivo **.envUser** para incluir suas credenciais de e-mail e as configurações de SMTP. Caso contrário, não irá funcionar

Passo a passo:
1. Localize o arquivo `.envUser` no diretório `core/`.
2. Abra o arquivo e insira suas informações conforme o exemplo abaixo:
```bash
EMAIL=seu-email@dominio.com
PASSWORD=sua-senha
SMTP=smtp.dominio.com
PORT=587
```

**⚠️ Atenção: Mantenha este arquivo seguro, pois ele contém informações confidenciais.**

---

## 🚀 Como Usar

Siga as etapas abaixo para clonar o repositório, instalar as dependências e configurar o arquivo `.envUser`.

### 1. Clone o Repositório

Clone o repositório em sua máquina utilizando o comando abaixo:

```bash
git clone https://github.com/seu-usuario/AppMail.git
```

## 📋 Pré-requisitos
Antes de começar, certifique-se de ter os seguintes itens instalados em sua máquina:

1. .NET 6.0
2. Visual Studio ou outro IDE compatível com C#
3. NuGet (caso queira gerenciar pacotes manualmente)


## 📦 Estrutura do Projeto
- **appMail/:** Contém a lógica principal da aplicação.
- **core/:** Módulo central e funções essenciais.
- **database/:** Contém o arquivo de dados Json, esse programa utiliza um json como BD.
- **archieve-pdf/:** Diretório onde os PDFs gerados são armazenados.
- **imagens/:** Armazena imagens, como logos que podem ser inseridos nos relatórios PDF.

## 🧾 Licença
Este projeto está licenciado sob licença livre. Pode usar a vontade !

## 📧 Contato
Caso tenha dúvidas, sugestões ou queira relatar algum problema, entre em contato:

- Email: wendson444@gmail.com
- Instagram: @wendson_magalhães
- Linkedin: https://www.linkedin.com/in/wendson-mayk-a856051bb/recent-activity/all/