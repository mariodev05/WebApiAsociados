using AsociadosUI.Models.Context;
using System.Collections.Generic;
using System.Linq;
using AsociadosUI.Repository;

namespace Salarios.asociados.Model
{
    public class ServiceAsociados : IAsociados
    {
        public List<Asociados> getListAsociados()
        {
            List<Asociados> listAsoc = new List<Asociados>();
            using (asoc_salariosEntities db = new asoc_salariosEntities()) {
                listAsoc = db
                    .Asociados
                    .ToList();            
            }
            return listAsoc;
        }


        public Asociados GetAsociados(int id) {

            Asociados asoc = new Asociados();           
            using (asoc_salariosEntities db = new asoc_salariosEntities())
            {
                asoc = db.Asociados
                    .Where(x => x.Id == id)
                    .FirstOrDefault();      
            }
            return asoc;
        }

        public int saveAsociado(Asociados asociados) {
            int cod = 0;
            using (asoc_salariosEntities db = new asoc_salariosEntities())
            {
                db.Asociados.Add(asociados);
                db.SaveChanges();
                cod = asociados.Id;
            }
            return cod;
        }

        public void deleteAsociado (Asociados asociados) {

            using (asoc_salariosEntities db = new asoc_salariosEntities())
            {
                db.Asociados.Attach(asociados);
                db.Entry(asociados).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }            
        }



        public Asociados updateAsociado(Asociados asociado) {
            Asociados asoc = new Asociados();
            asoc = GetAsociados(asociado.Id);

            asoc.Nombre_Asociado = asociado.Nombre_Asociado;
            asoc.Num_Asociado = asociado.Num_Asociado;
            asoc.Id = asociado.Id;
            asoc.Id_Salario = asociado.Id_Salario;

            using (asoc_salariosEntities db = new asoc_salariosEntities())
            {
                db.Asociados.Attach(asoc);
                db.Entry(asoc).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            Asociados asoc2 = new Asociados();
            asoc2 = GetAsociados(asociado.Id);
            return asoc2;
        }
    }
}
