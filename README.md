<h1> Auxílio para implementação do código da aplicação de upload de arquivos !</h1>

</br>

<p> Neste exemplo iremos utilizar algumas bibliotecas para facilitar a implementação de recursos dentro da aplicação, para isso será necessário instalar suas dependências. Então apenas recaptulando precisamos gerar um projeto em Asp .Net Core MVC utilizando o seguinte comando no terminal do seu ambiente de desenvolvimento: </p>

<b><p> dotnet new mvc --no-https --framework netcoreapp3.1 </p></b>

<p>(Lembrando que esse projeto será desenvolvido utilizando a versão 3.1 do SDK dotnet core, adeque o comando de acordo com suas necessidades)</p>

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
</br>
<span><b>Cole no Terminal: </b> dotnet add package Pomelo.EntityFrameworkCore.Design --version 3.0.0 </span>

<h1>:wrench: Configurações do Projeto</h1>

<p> Com todas as ferramentas e suas dependências devidamente instaladas podemos prosseguir para a configuração essencial do projeto, para isso precisamos seguir alguns passos que são primordias para que tudo funcione corretamente. Então vamos lá</p>

<h2>Estruturando o projeto</h2>

<p>Nosso projeto foi criado na estrutura MVC contendo as pastas Models, Viewa e Controllers, mas ainda precisamos implementar mais três pastas para organizar nosso projeto a fim de deixá-lo mais bem estruturado. A primeira pasta que precisamos é a que irá conter nosso modelo de contexto para o banco de dados, para isso crie a pasta "DataBase" (sem aspas) digitando o seguinte comando no seu terminal já estando dentro do diretório do projeto: </p>

<span><b>Cole no Terminal: </b> mkdir DataBase</span>

<p>Agora precisamos cirar nosso diretório de serviços, para isso digite ou cole o seguinte comando no seu terminal já estando dentro do diretório do projeto: </p>

<span><b>Cole no Terminal: </b> mkdir Services</span>

<p>Para finalizarmos com os diretórios iremos ainda precisar de um diretório para armazenar as imagens que iremos fazer upload, existem maneiras de se configurar o projeto para gerar esse diretório de forma dinâmica criando métodos específicos para essa geração, porém para encurtarmos mais os passos iremos cirar esse diretório de maneira manual. Precisamos saber que toda a manipulação de imagens será voltado para o diretório raiz de armazenamento de arquivos de esilização do nosso projeto, que por padrão em uma estrutura MVC é atribuído ao diretório <b>wwwroot</b>. Sabendo disso iremos acessar a pasta <b>wwwroot</b> dentro do nosso projeto e já dentro da pasta podemos criar nosso diretório que recebrá as imagens via Upload.</p>

<span><b>Acesse o diretório wwwroot: </b> cd wwwroot</span>

<span><b>Cole no Terminal dentro do diretório wwwroot: </b>mkdir Images</span>

<p>Com os diretórios criados prosseguimos para as demais configurações do nosso projeto.</p>

<h2>:inbox_tray: Importando as folhas de estilo (Css) do Bootstrap Icons e da ferramenta Light Box 2: </h2>

<p>Já instalamos as dependências para utilizarmos o Bootstrap Icons e o Light Box 2, mas para que eles funcionem no nosso projeto precisamos importá-los para o projeto, fazemos isso adicionando uma tag link para cada uma das importações no nosso arquivo <b>"Layout.cshtml"</b> dentro da tag <b>"head"</b> onde está configurado os demais links de Css da aplicação. Com o arquivo aberto crie duas tags <b>"link"</b> e passe os seguintes caminhos no <b>" href="" "</b>: </p>

<span><b>Link de Css para o Bootstrap Icons: </b> href="/lib/bootstrap-icons/font/bootstrap-icons.min.css" </span>

<span><b>Link de Css para o Light Box 2: </b> href="/lib/lightbox2/css/lightbox.min.css" </span>

<h2>:inbox_tray: Importando os arquivos JavaScript para utilizar a ferramenta Light Box 2: </h2>

<p>Ainda dentro do nosso arquivo <b>"Layout.cshtml"</b> precisamos passar a tag <b>"script"</b> que dará acesso aos arquivos JavaScript do light box 2, então vá até a linha anterior à linha de fechamento da sua tag body, ou na parte do seu código onde você está chamando pelos seus arquivos JavaScript e copie ou cole a seguinte referência dentro do parâmetro source de uma nova tag <b>"script"</b>: </p>

<span><b>Importando arquivos JavaScript do Light Box 2:</b> src="/lib/lightbox2/js/lightbox-plus-jquery.min.js" </span>

<p>Essas são todas as alterações que precisamos para o nosso arquivo <b>"Layout.cshtml"</b>, agora dando continuidade as configurações do nosso projeto precisamos criar três classes que implementarão nossos serviços de manipulação com imagens. Para que você tenha um maior auxílio você pode fazer o <b>"git clone"</b> ou <b>"git fork"</b> deste repositório e conferir os arquivos que serão citados aqui para que compreenda as alterações, ou simplesmente abrir estes arquivos pelo repositório remoto (todas as implementações de código estarão comentadas para um melhor entendimento).</p>

<h2>:wrench: Configurações da Classe <b>Startup.cs</b> </h2>

<p>Depois de clonar o repositório ou acessá-lo remotamente confira na classe <b>Startup.cs</b> as alterações necessárias no arquivo e as implemente de acordo com sua necessidade, basicamente nesta classe configuramos o uso de sessão e cookies e também as requisições feitas via protocolo Http já que não utilizaremos o Https aqui, ainda dentro da calsse Startup.cs configuramos também o uso do ImageSharp, a ferramenta que utilizaremos para manipulação das imagens. Após as configurações na interface de configuração adicionamos o uso delas ao Pipeline da aplicação. Verifique adequadamente as implementações na classe Startup.cs e adeque-as ao seu uso.</p>

<h2>:wrench: Criando as Classes de serviço </h2>

<p>Com as nossas configurações finalizadas agora podemos partir para a implementação das nossas Classes de serviço. Para isso utilizaremos de três Classes, a primeira delas será um interface onde iremos implementar as anotações dos nossos métodos de manipulação das imagens que no nosso projeto foi gerado como <b>/Services/IFileProcessor.cs</b>, em seguida criamos a calsse que irá implementar nossa interface chamada de  <b>/Services/FileProcessorService.cs</b> e por fim a classe enumarada que conterá nossos filtros e efeitos de edição das imagens chamada de <b>/Services/ImageEffects.cs</b> Lembre-se de consultar os arquivos no repositório para conferir os comentários de auxílio para a implementação</p>

<h2>:wrench: Criando as Classes Modelo da aplicação </h2>

<p>Com as classes de serviços implementadas podemos prosseguir para nossas classes modelo que definirão os atributos dos nossos objetos e a estrutura de geração das nossas tabelas do banco de dados que será gerado através das classes modelos como estamos utilizando o Entity Framework Core.</p>

<p>Utilizaremos aqui duas classes nomeadas no nosso projeto como <b>/Models/Gallery.cs</b> e <b>/Models/Image.cs</b> elas serão responsáveis por conter os atributos dos objetos que irão representar, confira os respectivos arquivos no repositório para verfificar os comentários de auxílio da implementação.</p>

<h2>:wrench: Criando e configurando a calsse de Contexto </h2>

<p>Agora partimos para a criação e configuração da nossa classe de contexto que irá gerenciar nossas manipulações com banco de dados. Dentro do diretório <b>DataBase</b> já criado adicione um arquivo .cs que será o seu contexto, no nosso projeto nomeamos como <b>/DataBase/GalleryContext.cs</b> é dentro dele que implementaremos as configurações para nossa conexão com banco de dados. Aqui basicamente iremos configurar um string de conexão que será passada dentro do método OnConfiguring(), no método OnModelCreating() configuramos a nomenclatura das tabelas ao serem criadas e por fim precisamos instanciar nossas tabelas através de um DbSet<> que será o objeto reponsável por conter toda a carga de dados das nossas tabelas. <b>Confira o arquivo no repositório para ter acesso aos comentários de auxílio da implementação</b> .<p>

<h2>:wrench: Criando e configurando as rotas e Views da aplicação </h2>

<p>Por Fim, Para finalizarmos podemos criar nossas controladoras que serão responsáveis por fazer as requisições de rotas para nossas páginas de vizualização e a estrutura utilizada aqui foi a seguinte: No diretório <b>Views</b> precisamos criar outros dois diretórios que serão responsáveis pelas páginas de vizualização de galerias e imagens, para isso dentro de Views crie um diretório que será utilizado pelas galerias, no nosso projeto nomeado como <b>/Views/Gallery</b>, e um outro responsável pelas Imagens nomeado no nosso projeto como <b>/Views/Image</b>, dentro desses dois diretórios teremos todos os nossos arquivos de vizualização do nosso projeto, aqui utilizamos views e partial views para acessar a visualização das páginas, para compreender melhor basta abrir os diretórios no repositório e verificar os comentários de auxílio. Ainda no diretório de Views temos uma pequena implementação ná página Index de Home <b>(Views/Home/Index.cshtml)</b> que será a página responsável por mostar nossa vitrine com todas as galerias cadastradas e suas respectivas imagens, confira também o arquivo comentado no nosso repositório.<p>

<h3>Controllers: </h3>

<p>Como já foi dito as controllers são responsáveis por tratar as nossas requisições para que retornem a vizualização das nossas páginas, para isso precisamos agora de dois arquivos Controlladores nomeados no projeto respectivamente como <b>/Controllers/GalleryController.cs</b> e <b>/Controllers/ImageController.cs</b>, nestes dois arquivos se encontram os códigos que tratam e validam as requisições para que possamos retornar as devidas páginas de vizualização, e ainda dentro das controllers no nosso arquivo <b>/Controllers/HomeController.cs</b>, precisamos alterar o nosso método Index para que este exiba nossa vitrine conforme foi implementado na nossa <b>/Views/Home/Index.cshtml</b> como já foi dito por aqui para facilitar você pode acessar os arquivos no repositório e conferir os comentários de auxílio.<p>

<p>Pois Bem, com isso temos toda a nossa estrutura e configurações necessárias para a aplicação.Lembre que todas as dúvidas poderão ser esclarecidadas ao vereficar os arquivos comentados dentro do nosso repositótio. Vamos ficando por aqui... Ate mais :raising_hand:<p>

