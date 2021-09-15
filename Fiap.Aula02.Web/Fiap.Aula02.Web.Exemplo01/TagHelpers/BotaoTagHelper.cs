using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Aula02.Web.Exemplo01.TagHelpers
{
    public class BotaoTagHelper : TagHelper
    {
        //Propriedades são os atributos da tag
        public string Texto { get; set; }
        public string Class { get; set; }

        //<botao texto="" class=""></botao>
        //<input type="submit" value="Cadastrar" class="btn btn-success"/>

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Definir o nome da tag
            output.TagName = "input";
            //Definir os atributos type, value e class
            output.Attributes.SetAttribute("type", "submit");

            if (string.IsNullOrEmpty(Texto))
                output.Attributes.SetAttribute("value", "Cadastrar");
            else
                output.Attributes.SetAttribute("value", Texto);

            //Ternário..
            output.Attributes.SetAttribute("class", string.IsNullOrEmpty(Class)?"btn btn-success":Class);
        }
    }
}
