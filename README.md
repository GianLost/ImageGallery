<h1> Auxílio para implementação do código da aplicação de upload de arquivos !</h1>

</br>

<p> Neste exemplos iremos utilizar algumas bibliotecas para facilitar a implementação de recursos dentro da aplicação, para isso será necessário instalar suas dependências. Então apenas recaptulando precisamos gerar um projeto em Asp .Net Core MVC utilizando o seguinte comando no terminal do seu ambiente de desenvolvimento: </p>

<b><p> dotnet new mvc --no-https --framework netcoreapp3.1 </p></b>

<p>(Lembrando que esse projeto será desenvolvido utilizando a versão 3.1 SDK do dotnet core, adeque o comando de acordo com suas necessidades)</p>

<p> Com o projeto gerado podemos prosseguir, dando seguimento precisamos instalar as dependências das ferramentas que iremos utilizar:</p>

<b><h2>:floppy_disk:  Instalando dependências do Libman: </h2></b>

<p>* Cole no Terminal: dotnet tool install -g Microsoft.Web.LibraryManager.Cli </p>

<b><h2>:floppy_disk:  Instalando dependências do Bootstrap Icons: </h2></b>

<p>* Cole no Terminal: libman install bootstrap-icons </p>

<b><h2>:floppy_disk:  Instalando dependências do LightBox 2: </h2></b>

<p>* Cole no Terminal: libman install lightbox2 </p>

<b><h2>:floppy_disk:  Instalando dependências do Image Sharp: </h2></b>

<p>* Cole no Terminal: dotnet add package SixLabors.ImageSharp </p>

<p>* Cole no Terminal: dotnet add package SixLabors.ImageSharp.Web </p>

<b><h2>:floppy_disk:  Instalando Entity Framework Core: </h2></b>

<p>* Cole no Terminal: dotnet tool install --global dotnet-ef --version 3.0.0 </p>

<b><h2>:floppy_disk:  Instalando pacotes de dependências para utilizar banco de dados MySql: </h2></b>

<p>* Cole no Terminal: dotnet add package Pomelo.EntityFrameworkCore.MySql --version 3.0.0 </p>

<<<<<<< HEAD
<p>* Cole no Terminal: dotnet add package Pomelo.EntityFrameworkCore.Design --version 3.0.0 </p>
=======
<p>* Cole no Terminal: dotnet add package Pomelo.EntityFrameworkCore.Design --version 3.0.0 </p>
>>>>>>> 127fea2d5827bccdff13965898119c2fac45678d
