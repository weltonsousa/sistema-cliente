using Microsoft.EntityFrameworkCore;
using SistemaCliente.Core.Entities;
using SistemaCliente.Core.Enum;
using SistemaCliente.Infrasctruture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCliente.Infra.Seeds
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, SistemaClienteDbContext context)
        {
            
            if (context.Clientes.Any())
                return;

           
            //ResetaIdentity(context);
            
            var tiposTelefone = new List<TiposTelefone>
            {
                new TiposTelefone
                {
                    DescricaoTipoTelefone = "Telefone móvel/celular",
                    Ativo = true,
                    UsuarioInsercao = "Sistema",
                    UsuarioAlteracao = "Sistema",
                },
                new TiposTelefone
                {
                    DescricaoTipoTelefone = "Telefone fixo residencial ou comercial",
                    Ativo = true,
                    UsuarioInsercao = "Sistema",
                    UsuarioAlteracao = "Sistema",
                },
                new TiposTelefone
                {
                    DescricaoTipoTelefone = "Telefone comercial da empresa",
                    Ativo = true,
                    UsuarioInsercao = "Sistema",
                    UsuarioAlteracao = "Sistema",
                },
                new TiposTelefone
                {
                    DescricaoTipoTelefone = "Número do WhatsApp",
                    Ativo = true,
                    UsuarioInsercao = "Sistema",
                    UsuarioAlteracao = "Sistema",
                }
            };

            context.TiposTelefones.AddRange(tiposTelefone);
            context.SaveChanges();



            var clientes = new List<Cliente>
            {
                new Cliente
                {
                    RazaoSocial = "João Silva Santos",
                    NomeFantasia = null,
                    TipoPessoa = TipoPessoa.Fisica,
                    Documento = "123.456.789-01",
                    Endereco = "Rua das Flores, 123",
                    Complemento = "Apt 101",
                    Bairro = "Centro",
                    Cidade = "São Paulo",
                    CEP = "01234-567",
                    UF = "SP",
                    Ativo = true,
                    UsuarioInsercao = "Sistema",
                    UsuarioAlteracao = "Sistema",
                    Telefones = new List<Telefone>
                    {
                        new Telefone
                        {
                            NumeroTelefone = "(11) 99999-1111",
                            Operadora = "Vivo",
                            Ativo = true,
                            CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone móvel/celular").CodigoTipoTelefone,
                            UsuarioInsercao = "Sistema",
                            UsuarioAlteracao = "Sistema",
                        }
                    }
                },


            new Cliente
            {               
                RazaoSocial = "Maria Oliveira Costa",
                NomeFantasia = null,
                TipoPessoa = TipoPessoa.Fisica,
                Documento = "987.654.321-09",
                Endereco = "Avenida Brasil, 456",
                Complemento = "Casa 2",
                Bairro = "Jardim América",
                Cidade = "Rio de Janeiro",
                CEP = "20123-456",
                UF = "RJ",
                Ativo = true,
                UsuarioInsercao = "Sistema",
                UsuarioAlteracao = "Sistema",
                Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        NumeroTelefone = "(21) 99876-5432",
                        Operadora = "Oi",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone móvel/celular").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    }
                }
            },

            new Cliente
            {               
                RazaoSocial = "Carlos Eduardo Mendes",
                NomeFantasia = null,
                TipoPessoa = TipoPessoa.Fisica,
                Documento = "456.789.123-45",
                Endereco = "Rua do Comércio, 789",
                Complemento = null,
                Bairro = "Vila Nova",
                Cidade = "Belo Horizonte",
                CEP = "30123-789",
                UF = "MG",
                Ativo = true,
                UsuarioInsercao = "Sistema",
                UsuarioAlteracao = "Sistema",
                Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        NumeroTelefone = "(21) 99876-5432",
                        Operadora = "Oi",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone móvel/celular").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    },
                    new Telefone
                    {
                        NumeroTelefone = "(31) 3234-5678",
                        Operadora = "Claro",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone fixo residencial ou comercial").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    }
                }
            },

            new Cliente
            {                
                RazaoSocial = "Ana Paula Rodrigues",
                NomeFantasia = null,
                TipoPessoa = TipoPessoa.Fisica,
                Documento = "321.654.987-12",
                Endereco = "Praça da Liberdade, 321",
                Complemento = "Bloco A, Apt 205",
                Bairro = "Liberdade",
                Cidade = "Salvador",
                CEP = "40123-321",
                UF = "BA",
                Ativo = false,
                UsuarioInsercao = "Sistema",
                UsuarioAlteracao = "Sistema",
               Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        NumeroTelefone = "(71) 98765-4321",
                        Operadora = "Tim",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone móvel/celular").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    },
                    new Telefone
                    {
                        NumeroTelefone = "(71) 3234-5678",
                        Operadora = "Vivo",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone fixo residencial ou comercial").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    }
                }
            },

            new Cliente
            {                
                RazaoSocial = "Tech Solutions Ltda",
                NomeFantasia = "TechSol",
                TipoPessoa = TipoPessoa.Juridica,
                Documento = "12.345.678/0001-90",
                Endereco = "Rua da Tecnologia, 1000",
                Complemento = "Sala 501",
                Bairro = "Brooklin",
                Cidade = "São Paulo",
                CEP = "04567-890",
                UF = "SP",
                Ativo = true,
                UsuarioInsercao = "Sistema",
                UsuarioAlteracao = "Sistema",
                Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        NumeroTelefone = "(11) 1234-5678",
                        Operadora = "Claro",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone comercial da empresa").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    },
                    new Telefone
                    {
                        NumeroTelefone = "(11) 98765-4321",
                        Operadora = "Tim",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Número do WhatsApp").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    }
                }
            },

            new Cliente
            {               
                RazaoSocial = "Comércio de Alimentos ABC S/A",
                NomeFantasia = "Mercado ABC",
                TipoPessoa = TipoPessoa.Juridica,
                Documento = "98.765.432/0001-10",
                Endereco = "Avenida dos Alimentos, 2500",
                Complemento = "Galpão 3",
                Bairro = "Distrito Industrial",
                Cidade = "Curitiba",
                CEP = "80123-456",
                UF = "PR",
                Ativo = true,
                UsuarioInsercao = "Sistema",
                UsuarioAlteracao = "Sistema",
               Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        NumeroTelefone = "(41) 1234-5678",
                        Operadora = "Oi",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone comercial da empresa").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    },
                    new Telefone
                    {
                        NumeroTelefone = "(41) 98765-4321",
                        Operadora = "Vivo",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Número do WhatsApp").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    }
                }
            },

            new Cliente
            {               
                RazaoSocial = "Construtora Cidade Nova Ltda",
                NomeFantasia = "Cidade Nova Construções",
                TipoPessoa = TipoPessoa.Juridica,
                Documento = "11.222.333/0001-44",
                Endereco = "Rua dos Engenheiros, 777",
                Complemento = null,
                Bairro = "Setor Oeste",
                Cidade = "Goiânia",
                CEP = "74123-777",
                UF = "GO",
                Ativo = true,
                UsuarioInsercao = "Sistema",
                UsuarioAlteracao = "Sistema",
                Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        NumeroTelefone = "(62) 1234-5678",
                        Operadora = "Tim",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone comercial da empresa").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    },
                    new Telefone
                    {
                        NumeroTelefone = "(62) 98765-4321",
                        Operadora = "Claro",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Número do WhatsApp").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    }
                }
            },

            new Cliente
            {               
                RazaoSocial = "Consultoria Empresarial JK Ltda",
                NomeFantasia = "JK Consultoria",
                TipoPessoa = TipoPessoa.Juridica,
                Documento = "55.666.777/0001-88",
                Endereco = "Avenida Paulista, 1500",
                Complemento = "Conjunto 1201",
                Bairro = "Bela Vista",
                Cidade = "São Paulo",
                CEP = "01310-100",
                UF = "SP",
                Ativo = true,
                UsuarioInsercao = "Sistema",
                UsuarioAlteracao = "Sistema",
               Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        NumeroTelefone = "(11) 1234-5678",
                        Operadora = "Vivo",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone comercial da empresa").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    },
                    new Telefone
                    {
                        NumeroTelefone = "(11) 98765-4321",
                        Operadora = "Oi",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Número do WhatsApp").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    }
                }
            },

            new Cliente
            {
                RazaoSocial = "Farmácia Popular do Brasil Ltda",
                NomeFantasia = "Farmácia Popular",
                TipoPessoa = TipoPessoa.Juridica,
                Documento = "33.444.555/0001-66",
                Endereco = "Rua da Saúde, 888",
                Complemento = "Loja 1",
                Bairro = "Centro",
                Cidade = "Fortaleza",
                CEP = "60123-888",
                UF = "CE",
                Ativo = true,
                UsuarioInsercao = "Sistema",
                UsuarioAlteracao = "Sistema",
                Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        NumeroTelefone = "(85) 1234-5678",
                        Operadora = "Tim",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone comercial da empresa").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    },
                    new Telefone
                    {
                        NumeroTelefone = "(85) 98765-4321",
                        Operadora = "Claro",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Número do WhatsApp").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    }
                }
            },

            new Cliente
            {                
                RazaoSocial = "Transportadora Rápida Express S/A",
                NomeFantasia = "Express Transportes",
                TipoPessoa = TipoPessoa.Juridica,
                Documento = "77.888.999/0001-22",
                Endereco = "Rodovia BR-101, Km 45",
                Complemento = "Galpão 15",
                Bairro = "Zona Industrial",
                Cidade = "Recife",
                CEP = "50123-999",
                UF = "PE",
                Ativo = false,
                UsuarioInsercao = "Sistema",
                UsuarioAlteracao = "Sistema",
                Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        NumeroTelefone = "(81) 1234-5678",
                        Operadora = "Oi",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Telefone comercial da empresa").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    },
                    new Telefone
                    {
                        NumeroTelefone = "(81) 98765-4321",
                        Operadora = "Vivo",
                        Ativo = true,
                        CodigoTipoTelefone = tiposTelefone.First(t => t.DescricaoTipoTelefone == "Número do WhatsApp").CodigoTipoTelefone,
                        UsuarioInsercao = "Sistema",
                        UsuarioAlteracao = "Sistema",
                    }
                }
            }};

            context.Clientes.AddRange(clientes);
            context.SaveChanges();

            Console.WriteLine("Seed data criado com sucesso!");
        }

        private static void ResetaIdentity(SistemaClienteDbContext context)
        {
            var tablesWithIdentity = new[] {
                "Clientes", "TiposTelefones", "Telefones"
            };

            foreach (var table in tablesWithIdentity)
            {
                try
                {
                    context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT ('{table}', RESEED, 0)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao resetar identity da tabela {table}: {ex.Message}");
                }
            }
        }
    }

}
