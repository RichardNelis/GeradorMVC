using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GeradorMVC
{
    public partial class FormGerador : Form
    {
        readonly String directory = @"C:\GeradorCodigo";

        public FormGerador()
        {
            InitializeComponent();

            CreateDirectory(directory);
        }

        private static void CreateDirectory(String path)
        {
            bool folderExists = Directory.Exists(path);

            if (!folderExists)
            {
                Directory.CreateDirectory(path);
            }
        }

        private static void CreateFile(String file, String text)
        {
            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(file))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(text);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }

        private void Btn_gerar_codigo_Click(object sender, EventArgs e)
        {
            String message;
            MessageBoxIcon msgBox;
            String path = $"{directory}\\{tb_controller.Text}";

            try
            {
                CamadaAplicacao(path);
                CamadaNegocio(path);

                message = "Código gerado com sucesso!\n";
                message += $"Caminho: {path}";
                msgBox = MessageBoxIcon.Information;
            }
            catch (Exception ex)
            {
                message = "Erro ao tentar gerar o código.";
                msgBox = MessageBoxIcon.Error;
            }

            MessageBox.Show(message, "Messagem", MessageBoxButtons.OK, msgBox);
        }

        // Camada Negocio
        private void CamadaNegocio(String path)
        {
            //Create path Controller
            String pathCN = $"{path}\\mvcCn\\{tb_controller.Text}";
            CreateDirectory(pathCN);

            StringBuilder code = new StringBuilder();
            code.AppendLine("using mvcframework.classes;")
                .AppendLine("using mvcframework.customMetadata;")
                .AppendLine($"using Sistema.{tb_sistema.Text}.Cn.mvcCn.Interface;")
                .AppendLine($"using Sistema.{tb_sistema.Text}.Cn.mvcCn.Repositorio;")
                .AppendLine("using System;")
                .AppendLine("using System.Collections.Generic;")
                .AppendLine("using System.ComponentModel;")
                .AppendLine("using System.ComponentModel.DataAnnotations;")
                .AppendLine("using System.ComponentModel.DataAnnotations.Schema;")
                .AppendLine("using System.Data.Entity;")
                .AppendLine("using System.Linq;")
                .AppendLine("")
                .AppendLine($"namespace Sistema.{tb_sistema.Text}.Cn.mvcCn.{tb_controller.Text}")
                .AppendLine("{")
                .AppendLine($"    [Table(\"{tb_tabela.Text.ToLower().Trim()}\", Schema = \"public\")]")
                .AppendLine($"    public class {tb_controller.Text} : ddAuditoria")
                .AppendLine("    {")
                .AppendLine("        [Key]")
                .AppendLine("        [Column(\"\")]")
                .AppendLine("        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]")
                .AppendLine($"        public int Id" + tb_controller.Text + " { get; set; }");

            int order = 0;

            for (int i = 0; i < (dg_Atributos.Rows.Count - 1); i++)
            {
                String coluna = dg_Atributos[0, i].Value.ToString().ToLower().Trim();
                String nome = dg_Atributos[1, i].Value.ToString().Trim();
                nome = nome.Substring(0, 1) + nome.Substring(1, nome.Length - 1);

                String nomeExibicao = dg_Atributos[2, i].Value.ToString();
                String tipo = dg_Atributos[3, i].Value.ToString();
                int.TryParse((String)dg_Atributos[4, i].Value, out int ckDataTable);

                code.AppendLine("")
                    .AppendLine($"        [Column(\"{coluna}\")]")
                    .AppendLine($"        [DisplayName(\"{nomeExibicao}\")]");

                if (ckDataTable == 1)
                {
                    order++;
                    code.AppendLine($"        [Columns(ColunmName = \"{nome}\", ColunmNameEx = \"{nomeExibicao}\", Order = {order})]");
                }

                code.AppendLine("        public " + tipo + " " + nome + " { get; set; }");
            }

            String db = tb_controller.Text.Substring(0, 1).ToLower() + tb_controller.Text.Substring(1, tb_controller.Text.Length - 1);

            code.AppendLine("    }")
                .AppendLine("")
                .AppendLine($"    public class {tb_controller.Text}Constructor")
                .AppendLine("    {")
                .AppendLine($"        public static cn{tb_controller.Text} {tb_controller.Text}EF() => new cn{tb_controller.Text}(new DAO{tb_controller.Text}());")
                .AppendLine("    }")
                .AppendLine("")
                .AppendLine($"    public class cn{tb_controller.Text}")
                .AppendLine("    {")
                .AppendLine($"        private IRepositorio<{tb_controller.Text}> repositorio;")
                .AppendLine($"        private DAO{tb_controller.Text} dao;")
                .AppendLine("")
                .AppendLine($"        public cn{tb_controller.Text}(IRepositorio<{tb_controller.Text}> irepositorio)")
                .AppendLine("        {")
                .AppendLine("            repositorio = irepositorio;")
                .AppendLine($"            dao = new DAO{tb_controller.Text}();")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine($"        public int Salvar({tb_controller.Text} entidade) => repositorio.Salvar(entidade);")
                .AppendLine("")
                .AppendLine($"        public IEnumerable<{tb_controller.Text}> ListarTodos() => repositorio.ListarTodos();")
                .AppendLine("")
                .AppendLine($"        public {tb_controller.Text} BuscarPorID(String id_codigo) => repositorio.BuscarPorID(id_codigo);")
                .AppendLine("    }")
                .AppendLine("")
                .AppendLine($"    class DAO{tb_controller.Text} : IRepositorio<{tb_controller.Text}>")
                .AppendLine("    {")
                .AppendLine($"        public bool Excluir({tb_controller.Text} entidade)")
                .AppendLine("        {")
                .AppendLine("            throw new NotImplementedException();")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine($"        public {tb_controller.Text} BuscarPorID(String id_codigo)")
                .AppendLine("        {")
                .AppendLine("            using (Contexto contexto = new Contexto())")
                .AppendLine("            {")
                .AppendLine("                int idCodigo = 0;")
                .AppendLine("                int.TryParse(id_codigo, out idCodigo);")
                .AppendLine("")
                .AppendLine($"                return contexto.{db}.FirstOrDefault(x => x.Id{tb_controller.Text} == idCodigo);")
                .AppendLine("            }")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine($"        public IEnumerable<{tb_controller.Text}> ListarTodos()")
                .AppendLine("        {")
                .AppendLine("            using (Contexto contexto = new Contexto())")
                .AppendLine("            {")
                .AppendLine($"                return contexto.{db}.ToList();")
                .AppendLine("            }")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine($"        public int Salvar({tb_controller.Text} entidade)")
                .AppendLine("        {")
                .AppendLine("            try")
                .AppendLine("            {")
                .AppendLine("                using (Contexto contexto = new Contexto())")
                .AppendLine("                {")
                .AppendLine($"                    if (entidade.Id{tb_controller.Text} == 0)")
                .AppendLine("                    {");

            for (int i = 0; i < (dg_Atributos.Rows.Count - 1); i++)
            {
                String coluna = dg_Atributos[0, i].Value.ToString();
                String nome = dg_Atributos[1, i].Value.ToString();
                String nomeExibicao = dg_Atributos[2, i].Value.ToString();
                String tipo = dg_Atributos[3, i].Value.ToString();

                code.AppendLine($"                        entidade.{nome} = entidade.{nome};");
            }

            code.AppendLine("                        new ddAuditoria().AuditaRegistro(entidade);")
                .AppendLine($"                        contexto.{db}.Add(entidade);")
                .AppendLine("                    }")
                .AppendLine("                    else")
                .AppendLine("                    {")
                .AppendLine($"                        {tb_controller.Text} atualizado = contexto.{db}.Find(entidade.Id{tb_controller.Text});");

            for (int i = 0; i < (dg_Atributos.Rows.Count - 1); i++)
            {
                String coluna = dg_Atributos[0, i].Value.ToString();
                String nome = dg_Atributos[1, i].Value.ToString();
                String nomeExibicao = dg_Atributos[2, i].Value.ToString();
                String tipo = dg_Atributos[3, i].Value.ToString();

                code.AppendLine($"                        atualizado.{nome} = entidade.{nome};");
            }

            code.AppendLine("")
                .AppendLine("                        new ddAuditoria().AuditaRegistro(atualizado);")
                .AppendLine("                        contexto.Entry(atualizado).State = EntityState.Modified;")
                .AppendLine("                    }")
                .AppendLine("")
                .AppendLine("                    contexto.SaveChanges();")
                .AppendLine($"                    return entidade.Id{tb_controller.Text};")
                .AppendLine("                }")
                .AppendLine("            }")
                .AppendLine("            catch (Exception ex)")
                .AppendLine("            {")
                .AppendLine("                throw ex;")
                .AppendLine("            }")
                .AppendLine("        }")
                .AppendLine("    }")
                .AppendLine("}");

            String pathCNFile = $"{pathCN}\\{tb_controller.Text}.cs";
            CreateFile(pathCNFile, code.ToString());
        }

        // Camada Aplicação
        private void CamadaAplicacao(String path)
        {
            CreateController(path);
            CreateModels(path);
            CreateViews(path);
        }

        private void CreateController(String path)
        {
            //Create path Controller
            String pathController = $"{path}\\Controllers\\{tb_controller.Text}";
            CreateDirectory(pathController);

            StringBuilder code = new StringBuilder();
            code.AppendLine("using mvcframework.classes;")
                .AppendLine("using mvcframework.customFilter;")
                .AppendLine("using mvcframework.retorno;")
                .AppendLine($"using Sistema.{cb_acesso.SelectedItem}.{tb_sistema.Text}.Models.{tb_controller.Text};")
                .AppendLine("using System.Web.Mvc;")
                .AppendLine("")
                .AppendLine($"namespace Sistema.{cb_acesso.SelectedItem}.{tb_sistema.Text}.Controllers.{tb_controller.Text}")
                .AppendLine("{")
                .AppendLine($"    public class {tb_controller.Text}Controller : Controller")
                .AppendLine("    {")
                .AppendLine("        public Mv" + tb_controller.Text + " mv { get; set; }")
                .AppendLine("")
                .AppendLine($"        public {tb_controller.Text}Controller()")
                .AppendLine("        {")
                .AppendLine($"            mv = new Mv{tb_controller.Text}();")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine("        public ActionResult Index()")
                .AppendLine("        {")
                .AppendLine("            return PartialView(mv);")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine("        public ActionResult Cadastro(int? Id)")
                .AppendLine("        {")
                .AppendLine("            if (Id.HasValue)")
                .AppendLine("            {")
                .AppendLine("                mv.BuscarById(Id.Value);")
                .AppendLine("            }")
                .AppendLine("")
                .AppendLine("            return PartialView(mv);")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine("        [HttpPost]")
                .AppendLine($"        public ActionResult Salvar(Mv{tb_controller.Text} mvPost)")
                .AppendLine("        {")
                .AppendLine("            Mensagens msg;")
                .AppendLine("")
                .AppendLine("            if (mvPost.Salvar())")
                .AppendLine("            {")
                .AppendLine("                msg = new Mensagens(Mensagens.Tipo_Mensagem.Complete)")
                .AppendLine("                {")
                .AppendLine($"                    Mensagem = \"{tb_controller.Text} salvo com sucesso!\"")
                .AppendLine("                };")
                .AppendLine("            }")
                .AppendLine("            else")
                .AppendLine("            {")
                .AppendLine("                msg = new Mensagens(Mensagens.Tipo_Mensagem.Erro)")
                .AppendLine("                {")
                .AppendLine($"                    Mensagem = \"Erro ao tentar salvar o {tb_controller.Text}.\"")
                .AppendLine("                };")
                .AppendLine("            }")
                .AppendLine("")
                .AppendLine("            return Content(msg.Return());")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine("        [AjaxOnly]")
                .AppendLine($"        public ActionResult _{tb_controller.Text}DataTables(JQueryDataTableParamModels param)")
                .AppendLine("        {")
                .AppendLine("            object data = new object();")
                .AppendLine($"            mv.{tb_controller.Text}DataTables(param, Request, out data);")
                .AppendLine("")
                .AppendLine("            return Json(data, JsonRequestBehavior.AllowGet);")
                .AppendLine("        }")
                .AppendLine("    }")
                .AppendLine("}");


            String pathControllerFile = $"{pathController}\\{tb_controller.Text}Controllers.cs";
            CreateFile(pathControllerFile, code.ToString());
        }

        private void CreateModels(String path)
        {
            //Create path Controller
            String pathModels = $"{path}\\Models\\{tb_controller.Text}";
            CreateDirectory(pathModels);

            StringBuilder code = new StringBuilder();
            code.AppendLine("using mvcframework.classes;")
                .AppendLine($"using Sistema.{tb_sistema.Text}.Cn.mvcCn.{tb_controller.Text};")
                .AppendLine("using System;")
                .AppendLine("using System.Collections.Generic;")
                .AppendLine("using System.Linq;")
                .AppendLine("using System.Web;")
                .AppendLine($"using dd = Sistema.{tb_sistema.Text}.Cn.mvcCn.{tb_controller.Text};")
                .AppendLine("")
                .AppendLine($"namespace Sistema.{cb_acesso.SelectedItem}.{tb_sistema.Text}.Models.{tb_controller.Text}")
                .AppendLine("{")
                .AppendLine($"    public class Mv{tb_controller.Text}")
                .AppendLine("    {")
                .AppendLine($"        public dd." + tb_controller.Text + " " + tb_controller.Text + " { get; set; }")
                .AppendLine("")
                .AppendLine($"        public Mv{tb_controller.Text}()")
                .AppendLine("        {")
                .AppendLine($"            {tb_controller.Text} = new dd.{tb_controller.Text}();")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine($"        public void {tb_controller.Text}DataTables(JQueryDataTableParamModels param, HttpRequestBase Request, out object data)")
                .AppendLine("        {")
                .AppendLine($"            IEnumerable<dd.{tb_controller.Text}> todosRegistros = {tb_controller.Text}Constructor.{tb_controller.Text}EF().ListarTodos();")
                .AppendLine($"            IEnumerable<dd.{tb_controller.Text}> registrosFiltrados = todosRegistros;")
                .AppendLine($"            Func<dd.{tb_controller.Text}, object> funcaoOrdenacao;")
                .AppendLine("            var colunaOrdenada = Convert.ToInt32(Request[\"iSortCol_0\"]);")
                .AppendLine("")
                .AppendLine("            var direcaoOrdenacao = Request[\"sSortDir_0\"];")
                .AppendLine("")
                .AppendLine($"            funcaoOrdenacao = (c => c.Id{tb_controller.Text});")
                .AppendLine("")
                .AppendLine("            var m = System.Web.Helpers.Json.Decode(Request[\"sSearch_0\"]);")
                .AppendLine("")
                .AppendLine("            if (m == null)")
                .AppendLine("            {")
                .AppendLine("                registrosFiltrados = todosRegistros;")
                .AppendLine("            }")
                .AppendLine("            else")
                .AppendLine("            {")
                .AppendLine("                registrosFiltrados = todosRegistros.Where(c => (");

            List<String> fieldsDataTable = new();

            for (int i = 0; i < (dg_Atributos.RowCount - 1); i++)
            {
                String nome = dg_Atributos[1, i].Value.ToString();
                String nomeExibicao = dg_Atributos[2, i].Value.ToString();
                String tipo = dg_Atributos[3, i].Value.ToString();
                int.TryParse((String)dg_Atributos[4, i].Value, out int ckDataTable);
                String format = FormatNome(tipo);

                String toUpper = tipo == "String" ? ".ToUpper()" : String.Empty;

                if (ckDataTable == 1)
                {
                    fieldsDataTable.Add($"                    (String.IsNullOrEmpty(c.{nome}{format}{toUpper}) || c.{nome}{format}{toUpper}.Contains(m.{nome}{format}{toUpper}.Trim()))");

                }
            }

            for (int i = 0; i < fieldsDataTable.Count; i++)
            {
                code.AppendLine(fieldsDataTable[i]);

                if (i < (fieldsDataTable.Count - 1))
                {
                    code.AppendLine("                    &&");
                }
            }

            code.AppendLine("                ));")
                .AppendLine("            }")
                .AppendLine("")
                .AppendLine("            if (direcaoOrdenacao == \"asc\")")
                .AppendLine("                registrosFiltrados = registrosFiltrados.OrderBy(funcaoOrdenacao);")
                .AppendLine("            else")
                .AppendLine("                registrosFiltrados = registrosFiltrados.OrderByDescending(funcaoOrdenacao);")
                .AppendLine("")
                .AppendLine("            var registrosExibidos = registrosFiltrados")
                .AppendLine("                .Skip(param.iDisplayStart)")
                .AppendLine("                .Take(param.iDisplayLength);")
                .AppendLine("")
                .AppendLine("            var result = from c in registrosExibidos")
                .AppendLine("                         select new[] {")
                .AppendLine($"                           c.Id{tb_controller.Text}.ToString()");

            for (int i = 0; i < (dg_Atributos.Rows.Count - 1); i++)
            {
                String nome = dg_Atributos[1, i].Value.ToString();
                String nomeExibicao = dg_Atributos[2, i].Value.ToString();
                String tipo = dg_Atributos[3, i].Value.ToString();
                int.TryParse((String)dg_Atributos[4, i].Value, out int ckDataTable);
                String format = FormatNome(tipo);

                if (ckDataTable == 1)
                {
                    if (i < (dg_Atributos.RowCount - 2))
                    {
                        code.Append("                         , ");
                    }

                    code.AppendLine($"c.{nome}{format}");

                }
            }

            code.AppendLine("                     };")
                .AppendLine("")
                .AppendLine("            data = new")
                .AppendLine("            {")
                .AppendLine("                sEcho = param.sEcho,")
                .AppendLine("                iTotalRecords = todosRegistros.Count(),")
                .AppendLine("                iTotalDisplayRecords = registrosFiltrados.Count(),")
                .AppendLine("                aaData = result")
                .AppendLine("            };")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine($"        public void BuscarById(int Id) => {tb_controller.Text} = {tb_controller.Text}Constructor.{tb_controller.Text}EF().BuscarPorID(Id.ToString());")
                .AppendLine("")
                .AppendLine($"        public bool Salvar() => {tb_controller.Text}Constructor.{tb_controller.Text}EF().Salvar({tb_controller.Text}) > 0;")
                .AppendLine("    }")
                .AppendLine("}");

            String pathModelsFile = $"{pathModels}\\Mv{tb_controller.Text}.cs";
            CreateFile(pathModelsFile, code.ToString());
        }

        private String FormatNome(String tipo)
        {
            String format = String.Empty;

            switch (tipo)
            {
                case "DateTime":
                    format = ".ToString(\"dd/MM/yyyy\")";
                    break;
                case "int":
                    format = ".ToString()";
                    break;
                case "decimal":
                    format = ".ToString(\"0.00\")";
                    break;
                default:
                    format = String.Empty;
                    break;
            }

            return format;
        }

        private void CreateViews(String path)
        {
            //Create path Controller
            String pathViews = $"{path}\\Views\\{tb_controller.Text}";
            CreateDirectory(pathViews);

            CreateViewsIndex(pathViews);

            CreateViewsCadastro(pathViews);
        }

        private void CreateViewsIndex(String path)
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine($"@model Sistema.{cb_acesso.SelectedItem}.{tb_sistema.Text}.Models.{tb_controller.Text}.Mv{tb_controller.Text}")
                .AppendLine("")
                .AppendLine("@{")
                .AppendLine($"    String caminho = \"app/{tb_sistema.Text.ToString().ToLower()}/{tb_controller.Text}\";")
                .AppendLine("}")
                .AppendLine("")
                .AppendLine($"<h2>{tb_controller.Text}</h2>")
                .AppendLine("")
                .AppendLine("<div class=\"form-group\">")
                .AppendLine($"    @Ajax.ActionLink(\"Cadastrar\", \"Cadastro\", \"{tb_controller.Text}\", new AjaxOptions")
                .AppendLine("{")
                .AppendLine("    UpdateTargetId = \"conteudo-principal\",")
                .AppendLine("    InsertionMode = InsertionMode.Replace,")
                .AppendLine("    HttpMethod = \"GET\"")
                .AppendLine("}, new { @class = \"btn btn-primary\" })")
                .AppendLine("</div>")
                .AppendLine("")
                .AppendLine("<div class=\"form-group\">")
                .AppendLine("    <div class=\"row col-md-12\">")
                .AppendLine("        <p class=\"alert alert-form\">Listagem</p>")
                .AppendLine("    </div>")
                .AppendLine("</div>")
                .AppendLine("")
                .AppendLine("<div class=\"form-group\">")
                .AppendLine("    <div class=\"row col-md-12\">")
                .AppendLine("        @{")
                .AppendLine($"            mvcframework.classes.ParametrosDataTable p = new mvcframework.classes.ParametrosDataTable(@Url.CustomUrl(caminho, \"_{tb_controller.Text}DataTables\").ToString());")
                .AppendLine("            p.urlSelect = @Url.CustomUrl(caminho, \"Cadastro\").ToString();")
                .AppendLine("        }")
                .AppendLine("")
                .AppendLine($"        @Html.CustomDataTables(new Sistema.{tb_sistema.Text}.Cn.mvcCn.{tb_controller.Text}.{tb_controller.Text}(), p)")
                .AppendLine("    </div>")
                .AppendLine("</div>");

            String pathViewsIndexFile = $"{path}\\Index.cshtml";

            CreateFile(pathViewsIndexFile, code.ToString());
        }

        private void CreateViewsCadastro(String path)
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine($"@model Sistema.{cb_acesso.SelectedItem}.{tb_sistema.Text}.Models.{tb_controller.Text}.Mv{tb_controller.Text}")
                .AppendLine("")
                .AppendLine("@{")
                .AppendLine($"    String caminho = \"app/{tb_sistema.Text.ToString().ToLower()}/{tb_controller.Text}\";")
                .AppendLine("}")
                .AppendLine("")
                .AppendLine($"<h2>{tb_controller.Text}</h2>")
                .AppendLine("")
                .AppendLine("<div class=\"form-group\">")
                .AppendLine("    <div class=\"row col-md-12\">")
                .AppendLine("        <p class=\"alert alert-form\">Formulário</p>")
                .AppendLine("    </div>")
                .AppendLine("</div>")
                .AppendLine("")
                .AppendLine("<div class=\"form-group\">")
                .AppendLine("    <div class=\"col-md-12\">")
                .AppendLine($"        @using (Ajax.BeginForm(\"Salvar\", \"{tb_controller.Text}\", new AjaxOptions()")
                .AppendLine("        {")
                .AppendLine("            HttpMethod = \"Post\",")
                .AppendLine("            OnBegin = \"LoadInit();\",")
                .AppendLine("            UpdateTargetId = \"resultado\",")
                .AppendLine("            InsertionMode = InsertionMode.Replace,")
                .AppendLine("            OnComplete = \"LoadFinal(); Mensagem();\"")
                .AppendLine("        }, new { @class = \"form-horizontal\", @role = \"form\" }))")
                .AppendLine("        {")
                .AppendLine("            @Html.AntiForgeryToken()")
                .AppendLine("            @Html.ValidationSummary(true)")
                .AppendLine("")
                .AppendLine($"            @Html.HiddenFor(model => Model.{tb_controller.Text}.Id{tb_controller.Text})")
                .AppendLine("");

            for (int i = 0; i < (dg_Atributos.Rows.Count - 1); i++)
            {
                String nome = dg_Atributos[1, i].Value.ToString();

                code.AppendLine("            <div class=\"row form-group\">")
                    .AppendLine("                @Html.LabelFor(model => model." + tb_controller.Text + "." + nome + ", new { @class = \"control-label col-md-2\" })")
                    .AppendLine("                <div class=\"col-md-8\">")
                    .AppendLine("                    @Html.CustomTextBoxFor(model => model." + tb_controller.Text + "." + nome + ", new { @value = Model." + tb_controller.Text + "." + nome + " })")
                    .AppendLine($"                    @Html.ValidationMessageFor(model => model.{tb_controller.Text}." + nome + ")")
                    .AppendLine("                </div>")
                    .AppendLine("            </div>")
                    .AppendLine("");
            }

            code.AppendLine("            <div class=\"row form-group\" style=\"margin-top: 50px; text-align: center; justify-content: space-between; column-gap: 20px; display: flex;\">")
                .AppendLine("                <button type=\"submit\" id=\"Salvar\" value=\"Salvar\" class=\"btn btn-primary\" style=\"width: 100px;\">Salvar</button>")
                .AppendLine("")
                .AppendLine($"                @Ajax.ActionLink(\"Voltar\", \"Index\", \"{tb_controller.Text}\", new AjaxOptions")
                .AppendLine("                {")
                .AppendLine("                    UpdateTargetId = \"conteudo-principal\",")
                .AppendLine("                    InsertionMode = InsertionMode.Replace,")
                .AppendLine("                    HttpMethod = \"GET\"")
                .AppendLine("                }, new { @class = \"btn btn-warning\", name = \"concluir\", style = \"width: 100px;\" })")
                .AppendLine("            </div>")
                .AppendLine("        }")
                .AppendLine("    </div>")
                .AppendLine("</div>");


            String pathViewsCadastroFile = $"{path}\\Cadastro.cshtml";
            CreateFile(pathViewsCadastroFile, code.ToString());
        }
    }
}
