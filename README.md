<h1> Auxílio para implementação do código da aplicação de upload de arquivos !</h1>

</br>

<p> Neste exemplos iremos utilizar algumas bibliotecas para facilitar a implementação de recursos dentro da aplicação, para isso será necessário instalar suas dependências. Então apenas recaptulando precisamos gerar um projeto em Asp .Net Core MVC utilizando o seguinte comando no terminal do seu ambiente de desenvolvimento: </p>

<b><p> dotnet new mvc --no-https --framework netcoreapp3.1 </p></b>

<p>(Lembrando que esse projeto será desenvolvido utilizando a versão 3.1 SDK do dotnet core, adeque o comando de acordo com suas necessidades)</p>

<p> Com o projeto gerado podemos prosseguir, dando seguimento precisamos instalar as dependências das ferramentas que iremos utilizar:</p>

<b><h2>:floppy_disk:  Instalando dependências do Libman: </h2></b>

<span> <b>Cole no Terminal: </b> dotnet tool install -g Microsoft.Web.LibraryManager.Cli </span>

<b><h2>:floppy_disk:  Instalando dependências do Bootstrap Icons: </h2></b>

<span><b>Cole no Terminal: </b> libman install bootstrap-icons </span>

<b><h2>:floppy_disk:  Instalando dependências do LightBox 2: </h2></b>

<span><b>Cole no Terminal: </b> libman install lightbox2 </span>

<b><h2>:floppy_disk:  Instalando dependências do Image Sharp: </h2></b>

<span><b>Cole no Terminal: </b> dotnet add package SixLabors.ImageSharp </span>

<span><b>Cole no Terminal: </b> dotnet add package SixLabors.ImageSharp.Web </span>

<b><h2>:floppy_disk:  Instalando o Serilog (Sistema de Logs que iremos utilizar na aplicação): </h2></b>

<span><b>Cole no Terminal: </b> dotnet add package Serilog.Extensions.Logging.File </span>

<b><h2>:floppy_disk:  Instalando Entity Framework Core: </h2></b>

<span><b>Cole no Terminal: </b> dotnet tool install --global dotnet-ef --version 3.0.0 </span>

<b><h2>:floppy_disk:  Instalando pacotes de dependências para utilizar banco de dados MySql: </h2></b>

<span><b>Cole no Terminal: </b> dotnet add package Pomelo.EntityFrameworkCore.MySql --version 3.0.0 </span>

<h1> Configurações do Projeto</h1>

<p> Com todas as ferramentas e suas dependências devidamente instaladas podemos prossegui para a configuração essencial do projeto, para isso precisamos seguir alguns passos que são primordias para que tudo funcione corretamente. Então vamos lá</p>

<h2>Estruturando o projeto</h2>

<p>Nosso projeto foi criado na estrutura MVC contendo as pastas Models, Viewa e Controllers, mas ainda precisamos implementar mais três pastas para organizar nosso projeto a fim de deixá-lo mais bem estruturado. A primeira pasta que precisamos é a que irá conter nosso modelo de contexto para o banco de dados, para isso crie a pasta "Data" (sem aspas) digitando o seguinte comando no seu terminal já estando dentro do diretório do projeto: </p>

<span><b>Cole no Terminal: </b> mkdir Data</span>

<p>Agora precisamos cirar nosso diretório de serviços, para isso digite ou cole o seguinte comando no seu terminal já estando dentro do diretório do projeto: </p>

<span><b>Cole no Terminal: </b> mkdir Services</span>

<p>Para finalizarmos com os diretórios iremos ainda precisar de um diretório para armazenar as imagens que iremos fazer upload, existem maneiras de se configurar o projeto para que gere esse diretório de forma dinâmica criando métodos específicos para essa geração, porém para encurtarmos mais os passos iremos cirar esse diretório de maneira manual. Precisamos saber que toda a manipulação de imagens será voltado para o diretório raiz de armazenamento de arquivos de esilização do nosso projeto, que por padrão em uma estrutura MVC é atribuído ao diretório <b>wwwroot</b>. Sabendo disso iremos acessar a pasta <b>wwwroot</b> dentro do nosso projeto e já dentro da pasta podemos criar nosso diretório que recebrá as imagens via Upload.</p>

<span><b>Acesse o diretório wwwroot: </b> cd wwwroot</span>

<span><b>Cole no Terminal dentro do diretório wwwroot: </b>mkdir Images</span>

<p>Com os diretórios criados prosseguimos para as demais configurações do nosso projeto.</p>

<h2> Importando as folhas de estilo (Css) do Bootstrap Icons e da ferramenta Light Box 2: </h2>

<p>Já instalamos as dependências para utilizarmos o Bootstrap Icons e o Light Box 2, mas para que eles funcionem no nosso projeto precisamos importá-los para o projeto, fazemos isso adicionando uma tag link para cada uma das importações no nosso arquivo <b>"Layout.cshtml"</b> dentro da tag <b>"head"</b> onde está configurado os demais links de Css da aplicação. Com o arquivo aberto adicione as seguintes linhas de código ao arquivo para importar o css das ferramentas: </p>

<span><b>Link de Css para o Bootstrap Icons: </b> <link rel="stylesheet" href="/lib/bootstrap-icons/font/bootstrap-icons.min.css" asp-append-version="true" /></span>