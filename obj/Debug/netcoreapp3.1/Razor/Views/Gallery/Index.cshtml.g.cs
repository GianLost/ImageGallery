#pragma checksum "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48c541251eb85167f78d557f551064cbd4dfeaf2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Gallery_Index), @"mvc.1.0.view", @"/Views/Gallery/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Ufo\Desktop\ImageGallery\Views\_ViewImports.cshtml"
using ImageGallery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ufo\Desktop\ImageGallery\Views\_ViewImports.cshtml"
using ImageGallery.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ufo\Desktop\ImageGallery\Views\_ViewImports.cshtml"
using ImageGallery.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ufo\Desktop\ImageGallery\Views\_ViewImports.cshtml"
using ImageGallery.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ufo\Desktop\ImageGallery\Views\_ViewImports.cshtml"
using ImageGallery.DataBase;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Ufo\Desktop\ImageGallery\Views\_ViewImports.cshtml"
using ImageGallery.Migrations;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48c541251eb85167f78d557f551064cbd4dfeaf2", @"/Views/Gallery/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0a6893e65cb3fdbac9639758049cc99a7b3513d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Gallery_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Gallery>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-dark mt-4 mb-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#registerGallery"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Criar galeria"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Image", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Adicionar Imagens"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Upgrade", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
  
    ViewData["Title"] = "Galeria de Imagens";

    Gallery gallery = new Gallery(); // objeto galeria para passarmos a model da partial View de cadastro de galerias.

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- A index de galria irá retornar os registros adicionados à tabela do banco de dados em uma tabela na aplicação que irá conter os dados percorridos e os botões de ação da View. Todas as modificações realizadas pelos botões serão realizadas via Partial Views que serão chamadas dentro de seus modais-->


<div class=""mt-2 p-2"">

    <!-- Botão que aciona o modal de cadastro de galerias -->

    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48c541251eb85167f78d557f551064cbd4dfeaf29109", async() => {
                WriteLiteral("<i class=\"bi bi-image-alt\"></i> Nova Galeria ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <!--Start Register Modal-->

    <div class=""modal fade"" id=""registerGallery"" tabindex=""-1"" role=""dialog"" aria-labelledby=""registerGalleryTitle""
        aria-hidden=""true"">

        <div class=""modal-dialog modal-dialog-centered"" role=""document"">

            <div class=""modal-content"">

                <div class=""modal-header"">

                    <h4 class=""mb-0"">Criar Galeria</h4>

                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">

                        <span aria-hidden=""true"">&times;</span>

                    </button>

                </div>

                <div class=""modal-body p-0"">

                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "48c541251eb85167f78d557f551064cbd4dfeaf211477", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 42 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = gallery;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" <!-- Chamada pa partial View do cadastro de galerias que recebe como model o objeto galeria -->\r\n\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n    <!--Finish Register Modal-->\r\n\r\n");
#nullable restore
#line 54 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
     if (Model.Count() > 0)
    {
        // Para cada galeria cadastrada será gerada uma linha na nossa tabela de forma dinâmica, para isso verificamos o número de registros e percorremos o modelo retornando os campos da tabela de acordo com as necesidades.


#line default
#line hidden
#nullable disable
            WriteLiteral("        <table class=\"table table-responsive table-bordered table-striped table-light table-hover table-gallery mb-4\">\r\n\r\n            <thead class=\"thead-dark\">\r\n\r\n                <tr>\r\n\r\n                    <th>");
#nullable restore
#line 64 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                   Write(Html.DisplayNameFor(m => m.IdGallery));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 65 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                   Write(Html.DisplayNameFor(m => m.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>Ações</th>\r\n\r\n                </tr>\r\n\r\n            </thead>\r\n\r\n            <tbody>\r\n");
#nullable restore
#line 73 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                 foreach (var item in Model)
                {
                    // Percorrendo o modelo com foreach para obter o retorno dos campos da tabela

                    // Os botões que acionam os modais precisam receber um data-target que representa o id passado na div modal, modais que contém formulários que validam os id's das suas models precisam também conter tanto no id do modal quanto no data-target que o aciona a carga da validação.


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 80 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                       Write(item.IdGallery.ToString("D6"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> <!--Id retornado no formato de string com 6 dígitos -->\r\n                        <td>");
#nullable restore
#line 81 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> <!-- Título da galeria -->\r\n\r\n                        <td>\r\n                            <!-- Link para a Página de imagens da galeria -->\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48c541251eb85167f78d557f551064cbd4dfeaf215986", async() => {
                WriteLiteral("<i class=\"bi bi-images\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                                  WriteLiteral(item.IdGallery);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                            <!-- Botão que aciona o modal de edição da galeria -->
                            <button class=""btn btn-sm btn-outline-secondary"" type=""button"" data-toggle=""modal""
                            data-target=""#upgradeGallery-");
#nullable restore
#line 90 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                                                    Write(item.IdGallery);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" title=\"Editar galeria\"><i\r\n                            class=\"bi bi-pencil\"></i></button> <!-- o data-target do botão que aciona o modal de atualização recebe o valor do id da div modal que irá acionar mais o valor da carga de validação \"upgradeGallery-");
#nullable restore
#line 91 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                                                                                                                                                                                                                             Write(item.IdGallery);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""-->

                            <!-- Botão que aciona o modal de exclusão da galeria -->
                            <button class=""btn btn-sm btn-outline-danger"" type=""button"" data-toggle=""modal""
                            data-target=""#deleteGallery-");
#nullable restore
#line 95 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                                                   Write(item.IdGallery);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" title=\"Excluir galeria\"><i\r\n                            class=\"bi bi-trash\"></i></button>\r\n                        </td>\r\n\r\n                    </tr>\r\n");
            WriteLiteral("                    <!--Start Upgrade Modal-->\r\n");
            WriteLiteral("                    <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 4594, "\"", 4629, 2);
            WriteAttributeValue("", 4599, "upgradeGallery-", 4599, 15, true);
#nullable restore
#line 103 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
WriteAttributeValue("", 4614, item.IdGallery, 4614, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" tabindex=\"-1\" role=\"dialog\"\r\n                        aria-labelledby=\"upgradeGalleryTitle\" aria-hidden=\"true\"> <!-- o id do modal de atualização recebe o valor do data-target que o aciona seguido da carga de validação para o modal \"upgradeGallery-");
#nullable restore
#line 104 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                                                                                                                                                                                                                     Write(item.IdGallery);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""-->

                        <div class=""modal-dialog modal-dialog-centered"" role=""document"">

                            <div class=""modal-content"">

                                <div class=""modal-header"">

                                    <h4 class=""mb-0"">Editar Galeria</h4>

                                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">

                                        <span aria-hidden=""true"">&times;</span>

                                    </button>

                                </div>

                                <div class=""modal-body p-0"">

                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "48c541251eb85167f78d557f551064cbd4dfeaf222352", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
#nullable restore
#line 124 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                </div>\r\n\r\n                            </div>\r\n\r\n                        </div>\r\n\r\n                    </div>\r\n");
            WriteLiteral("                    <!--Finish Upgrade Modal-->\r\n");
            WriteLiteral("                    <!--Start Delete Modal-->\r\n");
            WriteLiteral("                    <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 5912, "\"", 5946, 2);
            WriteAttributeValue("", 5917, "deleteGallery-", 5917, 14, true);
#nullable restore
#line 138 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
WriteAttributeValue("", 5931, item.IdGallery, 5931, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" tabindex=""-1"" role=""dialog""
                        aria-labelledby=""deleteGalleryTitle"" aria-hidden=""true"">

                        <div class=""modal-dialog modal-dialog-centered"" role=""document"">

                            <div class=""modal-content"">

                                <div class=""modal-header"">

                                    <h3 class=""modal-title text-danger text-center mb-0 p-0"" id=""deleteGalleryTitle"">
                                        Alerta!</h3>

                                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">

                                        <span aria-hidden=""true"">&times;</span>

                                    </button>

                                </div>

                                <div class=""modal-body p-0"">

                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "48c541251eb85167f78d557f551064cbd4dfeaf225648", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
#nullable restore
#line 160 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                </div>\r\n\r\n                            </div>\r\n\r\n                        </div>\r\n\r\n                    </div>\r\n");
            WriteLiteral("                    <!--Finish Delete Modal-->\r\n");
#nullable restore
#line 171 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n\r\n        </table>\r\n");
#nullable restore
#line 175 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
    }
    else
    {
        // Caso nenhum registro seja encontrado uma div de aviso será retornada contendo a mensagem de que não há registros.


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-warning\" role=\"alert\">\r\n            Nenhuma galeria cadastrada.\r\n        </div>\r\n");
#nullable restore
#line 183 "C:\Users\Ufo\Desktop\ImageGallery\Views\Gallery\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Gallery>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
