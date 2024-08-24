using AsociadosUI.Models.Context;
using System.Collections.Generic;

namespace AsociadosUI.Repository
{
    public interface IAsociados
    {
        List<Asociados> getListAsociados();

        Asociados GetAsociados(int id);

        int saveAsociado(Asociados asociados);

        void deleteAsociado(Asociados asociados);

        Asociados updateAsociado(Asociados asociado);


    }
}
