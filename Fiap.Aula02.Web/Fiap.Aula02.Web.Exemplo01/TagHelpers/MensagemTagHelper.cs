using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Aula02.Web.Exemplo01.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        public string Texto { get; set; }

        //<mensagem texto=""></mensagem>
        //<div class="aler alert-success">texto</div>

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Definir o nome da tag
            output.TagName = "div";
            //Definir o atributo class
            output.Attributes.SetAttribute("class", "alert alert-success");
            //Definir o conteúdo da tag
            output.Content.SetContent(Texto);

            if (string.IsNullOrEmpty(Texto)) //Validar se o texto não está vazio ou null
            {
                output.Attributes.SetAttribute("hidden", ""); //Define a div oculta
            }
        }
    }
}
