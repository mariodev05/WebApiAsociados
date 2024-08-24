using AsociadosUI.Models.Context;
using System.Collections.Generic;

namespace AsociadosUI.Repository
{
    public interface IDepartamento
    {
        List<Departamentos> getListDepartamentos();

        Departamentos GetDepartamentos(int id);

        int saveDepartamentos(Departamentos departamentos);

        void deleteDepartamentos(Departamentos departamentos);

        int updateDepartamentos (Departamentos departamentos);

    }
}
