﻿using Microsoft.EntityFrameworkCore;
using webapi_healthclinic_tarde.Contexts;
using webapi_healthclinic_tarde.Domains;
using webapi_healthclinic_tarde.Interfaces;

namespace webapi_healthclinic_tarde.Repositories
    {
    public class ProntuarioRepository : IProntuarioRepository
        {
#pragma warning disable IDE0052
        private readonly HealthClinicContext ctx;
#pragma warning restore IDE0052

        public ProntuarioRepository()
            {
            ctx = new HealthClinicContext();
            }

        public void Atualizar(Guid id, Prontuario prontuarioAtualizado)
            {
            try
                {
                Prontuario prontuario = BuscarPorId(id) ?? throw new Exception("Prontuario não encontrada");

                prontuario.Descricao = prontuarioAtualizado.Descricao;
                prontuario.IdConsulta = prontuarioAtualizado.IdConsulta;

                ctx.Prontuario.Update(prontuario);
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Prontuario BuscarPorId(Guid id)
            {
            try
                {
                return ctx.Prontuario.Select(p => new Prontuario
                    {
                    IdProntuario = p.IdProntuario,
                    Descricao = p.Descricao,
                    IdConsulta = p.IdConsulta,

                    IdConsultaNavigation = new Consulta
                        {
                        IdConsulta = p.IdConsultaNavigation.IdConsulta,
                        Data = p.IdConsultaNavigation!.Data,
                        IdMedico = p.IdConsultaNavigation.IdMedico,
                        IdPaciente = p.IdConsultaNavigation.IdPaciente,
                        }
                    }).FirstOrDefault(c => c.IdProntuario == id)!;
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void Cadastrar(Prontuario novoProntuario)
            {
            try
                {
                ctx.Prontuario.Add(novoProntuario);
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
                ctx.Prontuario.Remove(BuscarPorId(id));
                ctx.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Prontuario> Listar()
            {
            try
                {
                return ctx.Prontuario.Select(p => new Prontuario
                    {
                    IdProntuario = p.IdProntuario,
                    Descricao = p.Descricao,
                    IdConsulta = p.IdConsulta,

                    IdConsultaNavigation = new Consulta
                        {
                        Data = p.IdConsultaNavigation!.Data,
                        IdMedico = p.IdConsultaNavigation.IdMedico,
                        IdPaciente = p.IdConsultaNavigation.IdPaciente,
                        IdSituacao = p.IdConsultaNavigation.IdSituacao,
                        Horario = p.IdConsultaNavigation.Horario,
                        }
                    }).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        }
    }
