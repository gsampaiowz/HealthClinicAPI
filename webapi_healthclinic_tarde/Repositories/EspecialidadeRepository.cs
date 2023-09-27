﻿using Microsoft.EntityFrameworkCore;
using webapi_healthclinic_tarde.Contexts;
using webapi_healthclinic_tarde.Domains;
using webapi_healthclinic_tarde.Interfaces;

namespace webapi_healthclinic_tarde.Repositories
    {
    public class EspecialidadeRepository : IEspecialidadeRepository
        {
#pragma warning disable IDE0052
        private readonly HealthClinicContext ctx;
#pragma warning restore IDE0052

        public EspecialidadeRepository()
            {
            ctx = new HealthClinicContext();
            }

        public void Atualizar(Guid id, Especialidade especialidadeAtualizada)
            {
            try
                {
                Especialidade especialidade = BuscarPorId(id) ?? throw new Exception("Especialidade não encontrada");

                especialidade.NomeEspecialidade = especialidadeAtualizada.NomeEspecialidade;

                ctx.Especialidade.Update(especialidade);
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Especialidade BuscarPorId(Guid id)
            {
            try
                {
                return ctx.Especialidade.Find(id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Especialidade novaEspecialidade)
            {
            try
                {
                ctx.Especialidade.Add(novaEspecialidade);
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Deletar(Guid id)
            {
            try
                {
                ctx.Especialidade.Remove(BuscarPorId(id));
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Especialidade> Listar()
            {
            try
                {
                return ctx.Especialidade.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
