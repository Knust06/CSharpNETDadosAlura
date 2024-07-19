using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal abstract class DAL<T> where T : class
{
    protected readonly ScreenSoundContext context;

    protected DAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    public IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }
    public void Adicionar(T entidade)
    {
        context.Set<T>().Add(entidade);
        context.SaveChanges();
    }
    public void Atualizar(T entidade)
    {
        context.Set<T>().Update(entidade);
        context.SaveChanges();
    }
    public void Deletar(T entidade)
    {
        context.Set<T>().Remove(entidade);
        context.SaveChanges();
    }
    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }

}
