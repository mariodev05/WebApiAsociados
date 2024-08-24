using AsociadosUI.Models.Context;
using AsociadosUI.Repository;
using Salarios.asociados.Model;
using System.Collections.Generic;

namespace AsociadosUI.Components
{
    public class AsociadoComponent
    {
        public List<Asociados> getListAsociados()
        {
            IAsociados asoc = new ServiceAsociados();
            return asoc.getListAsociados();
        }

        public int AddAsociados(Asociados asocs)
        {
            IAsociados asoc = new ServiceAsociados();
            return asoc.saveAsociado(asocs);
        }

        public Asociados GetAsociados(int id)
        {
            IAsociados asoc = new ServiceAsociados();
            return asoc.GetAsociados(id);
        }

        public Asociados UpdateAsociados(Asociados asocs)
        {
          
            IAsociados asoc = new ServiceAsociados();
            return asoc.updateAsociado(asocs);
        }
    }
}
