using ApiDibra.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiDibra.Controllers
{
    [EnableCors("*", "*", "*")]
    [AllowAnonymous]
    public class ChamadoController : ApiController
    {
        private DbDibraContext db;

        public ChamadoController()
        {
            db = new DbDibraContext();
        }

        // GET api/chamado
        public IEnumerable<Chamado> Get()
        {
            IEnumerable<Chamado> chamados = db.Chamados.AsEnumerable();
            return chamados;
        }

        // GET api/chamado/<numero>
        public IHttpActionResult Get(int id)
        {
            Chamado chamado= db.Chamados.Find(id);

            if (chamado == null)
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Chamado não localizado."));
            else
                return ResponseMessage(Request.CreateResponse<Chamado>(HttpStatusCode.OK, chamado));
        }

        // POST api/chamado
        public IHttpActionResult Post([FromBody] JObject dados)
        {
            if (dados != null)
            {
                //var prod = JsonConvert.DeserializeObject<Produto>(dados.ToString());
                Chamado chamado = Newtonsoft.Json.JsonConvert.DeserializeObject<Chamado>(dados.ToString());

                db.Chamados.Add(chamado);
                db.SaveChanges();
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Erro na gravacao do Pedido."));
        }

        // PUT api/chamado/<numero>
        public IHttpActionResult Put(int id, Chamado chamado)
        {
            /*
            Produto findProd = db.Produtos.Find(id);
            if (findProd != null)
            {
                produto.id = findProd.id;
                produto.nome = findProd.nome;
                produto.valor = findProd.valor;
                produto.imagem = findProd.imagem;
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Produto não localizado para alteração."));
           */
            return null;
        }

        // DELETE api/produto/5
        public IHttpActionResult Delete(int id)
        {
            
            Chamado chamado = db.Chamados.Find(id);
            if (chamado != null)
            {
                db.Chamados.Remove(chamado);
                db.SaveChanges();
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
                return ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NotFound, "Produto não localizado para exclusão."));
            
        }
    }
}
