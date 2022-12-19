<h1> Auxílio para implementação do código da aplicação de upload de arquivos !</h1>

</br>

<p> Para este exemplo serão necessárias algumas bibliotecas que facilitarão a implementação de recursos dentro da aplicação, para que tudo funcione corretamente será necessário instalar suas dependências. Para começar gere um projeto em Asp .Net Core MVC utilizando o seguinte comando no terminal do seu ambiente de desenvolvimento: </p>

<b><p> dotnet new mvc --no-https --framework netcoreapp3.1 </p></b>

<p>(Lembrando que esse projeto está baseado na versão 3.1 do SDK dotnet core, adeque o comando às suas necessidades)</p>

<p> Com o projeto gerado podemos agora instalar as dependências das ferramentas que serão utilizadas:</p>

<b><h2>:floppy_disk: Instalando as dependências do Libman: </h2></b>

<span> <b>Cole no Terminal: </b> dotnet tool install -g Microsoft.Web.LibraryManager.Cli </span>

<b><h2>:floppy_disk: Instalando as dependências do Bootstrap Icons: </h2></b>

<span><b>Cole no Terminal: </b> libman install bootstrap-icons </span>

<b><h2>:floppy_disk: Instalando as dependências do LightBox 2: </h2></b>

<span><b>Cole no Terminal: </b> libman install lightbox2 </span>

<b><h2>:floppy_disk: Instalando as dependências do Image Sharp: </h2></b>

<span><b>Cole no Terminal: </b> dotnet add package SixLabors.ImageSharp </span>

<span><b>Cole no Terminal: </b> dotnet add package SixLabors.ImageSharp.Web </span>

<b><h2>:floppy_disk: Instalando o Serilog (Sistema de Logs que iremos utilizar na aplicação): </h2></b>

<span><b>Cole no Terminal: </b> dotnet add package Serilog.Extensions.Logging.File </span>

<b><h2>:floppy_disk: Instalando o Entity Framework Core: </h2></b>

<span><b>Cole no Terminal: </b> dotnet tool install --global dotnet-ef --version 3.0.0 </span>

<b><h2>:floppy_disk: Instalando pacotes de dependências para utilizar banco de dados MySql: </h2></b>

<span><b>Cole no Terminal: </b> dotnet add package Pomelo.EntityFrameworkCore.MySql --version 3.0.0 </span>
</br>
<span><b>Cole no Terminal: </b> dotnet add package Pomelo.EntityFrameworkCore.Design --version 3.0.0 </span>

<h1>:wrench: Configurações do Projeto</h1>

<p> Com todas as ferramentas e suas dependências devidamente instaladas podemos prosseguir para a configuração essencial do projeto. Então vamos lá !</p>

<h2>Estruturando o projeto</h2>

<p>O projeto foi criado na estrutura MVC contendo as pastas Models, Views e Controllers, mas ainda será necessário implementar mais três pastas para organizar o projeto a fim de deixá-lo mais bem estruturado. A primeira pasta irá conter o modelo de contexto para o banco de dados, para isso crie a pasta "DataBase" (sem aspas) digitando o seguinte comando no seu terminal já dentro do diretório do projeto: </p>

<span><b>Cole no Terminal: </b> mkdir DataBase</span>

<p>Agora será preciso cirar o diretório de serviços, para isso digite ou cole o seguinte comando no seu terminal já dentro do diretório do projeto: </p>

<span><b>Cole no Terminal: </b> mkdir Services</span>

<p>Para finalizar com os diretórios ainda será necessário um para armazenar as imagens salvas via upload, existem maneiras de se configurar o projeto para gerar esse diretório de forma dinâmica criando métodos específicos para essa geração, porém para simplificarmos os passos iremos criá-lo manualmente. Atente-se pois toda a manipulação de imagens será voltada para o diretório raiz de armazenamento de arquivos de esilização do projeto, que por padrão em uma estrutura MVC é atribuído ao diretório <b>wwwroot</b>. Sabendo disso acesse a pasta <b>wwwroot</b> dentro do projeto e estando dentro da pasta crie o diretório que recebrá as imagens via Upload.</p>

<span><b>Acesse o diretório wwwroot: </b> cd wwwroot</span>

<span><b>Cole no Terminal dentro do diretório wwwroot: </b>mkdir Images</span>

<p>Com os diretórios criados prossiga para as demais configurações do projeto.</p>

<h2>:inbox_tray: Importe as folhas de estilo (Css) do Bootstrap Icons e da ferramenta Light Box 2: </h2>

<p>Já foram instaladas as dependências para que se possa utilizar o Bootstrap Icons e o Light Box 2, mas para que eles funcionem corretamente é precisao importá-los para o projeto, faça isso adicionando uma tag link para cada uma das importações no arquivo <b>"Layout.cshtml"</b> dentro da tag <b>"head"</b> onde está configurado os demais links de Css da aplicação. Com o arquivo aberto crie duas tags <b>"link"</b> e passe os seguintes caminhos no <b>" href="" "</b>: </p>

<span><b>Link de Css para o Bootstrap Icons: </b> href="/lib/bootstrap-icons/font/bootstrap-icons.min.css" </span>

<span><b>Link de Css para o Light Box 2: </b> href="/lib/lightbox2/css/lightbox.min.css" </span>

<h2>:inbox_tray: Importe os arquivos JavaScript para utilizar a ferramenta Light Box 2: </h2>

<p>Ainda dentro do arquivo <b>"Layout.cshtml"</b> crie uma tag <b>"script"</b> que dará acesso aos arquivos JavaScript do light box 2 dentro do projeto, então vá até a linha anterior à linha de fechamento da tag body, ou na parte do seu código onde você está chamando pelos seus arquivos JavaScript e copie ou cole a seguinte referência dentro do parâmetro source de uma nova tag <b>"script"</b>: </p>

<span><b>Importando arquivos JavaScript do Light Box 2:</b> src="/lib/lightbox2/js/lightbox-plus-jquery.min.js" </span>

<p>Essas são todas as alterações necessárias para o arquivo <b>"Layout.cshtml"</b>. Continuando as configurações do projeto será necessário criar três classes responsáveis pela implementação dos serviços de manipulação de imagens. Para que você tenha um maior auxílio você pode fazer o <b>"git clone"</b> ou <b>"git fork"</b> deste repositório e conferir os arquivos que serão citados aqui para que compreenda as alterações, ou simplesmente abrir estes arquivos pelo repositório remoto (todas as implementações no código estarão comentadas para um melhor entendimento).</p>

<h2>:wrench: Configurações da Classe <b>Startup.cs</b> </h2>

<p>Depois de clonar o repositório ou acessá-lo remotamente confira a classe <b>Startup.cs</b> nesta classe estão configurados o uso de sessão e cookies e também as requisições feitas via protocolo Http já que não optamos por não utilizar o Https no exemplo, ainda dentro da calsse Startup.cs também se encontra configurado o uso do ImageSharp, a ferramenta que  será utilizada para manipulação das imagens. Após as configurações na interface adicionamos o uso delas ao Pipeline da aplicação. Verifique adequadamente as implementações na classe Startup.cs e adeque-as ao seu uso.</p>

<h2>:wrench: Criando as Classes de serviço </h2>

<p>Com as configurações finalizadas agora implemente as Classes de serviço. Utilize três Classes, a primeira sendo uma interface onde as anotações dos métodos de manipulação das imagens será implementada, gerada no projeto como <b>/Services/IFileProcessor.cs</b>, em seguida crie a calsse que irá implementar a interface. chamada de  <b>/Services/FileProcessorService.cs</b> e por fim a classe enumerada que conterá  filtros e efeitos de edição das imagens chamada <b>/Services/ImageEffects.cs</b> Consulte os arquivos no repositório para conferir os comentários de auxílio para a implementação</p>

<h2>:wrench: Criando as Classes de Modelo </h2>

<p>Com as classes de serviço implementadas defina agora as classes modelo que armazenarão os atributos dos objetos e a estrutura de geração das tabelas do banco de dados gerado utilizando o Entity Framework Core.</p>

<p>Foram utilizadas duas classes nomeadas como <b>/Models/Gallery.cs</b> e <b>/Models/Image.cs</b> elas serão responsáveis por conter os atributos dos objetos que irão representar, confira os respectivos arquivos no repositório para verfificar os comentários de auxílio da implementação.</p>

<h2>:wrench: Criando e configurando a calsse de Contexto </h2>

<p>Agora crie e configure a classe de contexto que irá gerenciar as manipulações com banco de dados. Dentro do diretório <b>DataBase</b> já criado adicione um arquivo .cs que será o seu contexto, no projeto nomeado como <b>/DataBase/GalleryContext.cs</b>. Dentro dele implemente as configurações para conexão com banco de dados. Configure um string de conexão no método OnConfiguring(), no método OnModelCreating() configure a nomenclatura das tabelas ao serem geradas e por fim instancie as tabelas através de um DbSet<> que será o objeto reponsável por conter toda a carga de dados das tabelas. <b>Confira o arquivo no repositório para ter acesso aos comentários de auxílio da implementação</b> .<p>

<h2>:wrench: Criando e configurando as rotas e Views da aplicação </h2>

<p>Para finalizar crie controladoras que serão responsáveis por controlar as requisições submetidas para as páginas de vizualização. No diretório <b>Views</b> crie dois diretórios responsáveis pelas páginas de vizualização de galerias e imagens, para isso dentro de Views crie um diretório que será utilizado pelas galerias, no projeto nomeado como <b>/Views/Gallery</b>, e um outro responsável pelas Imagens nomeado no projeto como <b>/Views/Image</b>, dentro desses dois diretórios teremos todos os arquivos de vizualização do projeto, foram utilizadas views e partial views para gerar a visualização de páginas, para compreender melhor abra os diretórios no repositório e verifique os comentários de auxílio. Ainda no diretório de Views implemente também de acordo com os comentários do arquivo na página Index de Home <b>(Views/Home/Index.cshtml)</b> que será a página responsável por mostar a vitrine com todas as galerias cadastradas e suas respectivas imagens, confira o arquivo comentado no repositório do projeto.<p>

<h3>Controllers: </h3>

<p>Como já foi dito as controllers são responsáveis por tratar as requisições para que retornem a vizualização páginas, Sabendo disso crie agora dois arquivos Controlladores nomeados no projeto respectivamente como <b>/Controllers/GalleryController.cs</b> e <b>/Controllers/ImageController.cs</b>, nestes dois arquivos se encontram os códigos que tratam e validam as requisições para que sejam retornardas as devidas páginas de vizualização, e ainda dentro das controllers no arquivo <b>/Controllers/HomeController.cs</b>, será necessário alterar o método Index para que este exiba a vitrine conforme foi implementado na <b>/Views/Home/Index.cshtml</b> como já foi dito por aqui para facilitar você pode acessar os arquivos no repositório e conferir os comentários de auxílio.<p>

<p>Pois Bem, com isso temos toda a nossa estrutura e configurações necessárias para a aplicação.Lembre que todas as dúvidas poderão ser esclarecidadas ao vereficar os arquivos comentados dentro do nosso repositório. Vamos ficando por aqui... Ate mais :raising_hand:<p>

