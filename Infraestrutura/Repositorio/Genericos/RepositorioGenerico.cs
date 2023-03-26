using Dominio.Interfaces.Generics;
using Infraestrutura.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio.Genericos
{
    public class RepositorioGenerico<T> : IGenericos<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<Contexto> _contexto;

        public RepositorioGenerico()
        {
            _contexto = new DbContextOptions<Contexto>();
        }

        public async Task Adiciona(T objetc)
        {
            using (var data = new DbContext(_contexto))
            {
                await data.Set<T>().AddAsync(objetc);
                await data.SaveChangesAsync();
            }
        }

        public async Task Atualizar(T objetc)
        {
            using (var data = new DbContext(_contexto))
            {
                 data.Set<T>().Update(objetc);
                 await data.SaveChangesAsync();
            }
        }

        public async Task<T> BuscarPorId(int Id)
        {
            using (var data = new DbContext(_contexto))
            {
                return await  data.Set<T>().FindAsync(Id);
            }
        }


        public async Task Excluir(T objetc)
        {
            using (var data = new DbContext(_contexto))
            {
                data.Set<T>().Remove(objetc);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<T>> ListarTodos()
        {
            using (var data = new DbContext(_contexto))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
