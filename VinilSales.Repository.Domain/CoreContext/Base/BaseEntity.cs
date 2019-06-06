﻿using System;
using VinilSales.Domain.CoreContext.Enum;

namespace VinilSales.Repository.Domain.CoreContext.Base
{
    public abstract class BaseEntity
    {
        private const string DEFAULT_STATUS_ATIVO = "Ativo";
        private const string DEFAULT_STATUS_INATIVO = "Inativo";

        public BaseEntity()
        {
            Ativar();
        }

        public DateTime DataHoraCadastro { get; protected set; }
        public DateTime DataHoraAlteracao { get; set; }
        public byte Status { get; protected set; }
        
        public virtual void Ativar()
        {
            this.Status = (byte)(int)Enum.Parse(typeof(DefaultStatusEnum), DEFAULT_STATUS_ATIVO);
        }
        public virtual void Inativar()
        {
            this.Status = (byte)(int)Enum.Parse(typeof(DefaultStatusEnum), DEFAULT_STATUS_INATIVO);
        }

        public static class Factory
        {
            public static T CreateInstance<T>() where T : BaseEntity
            {
                var entity = Activator.CreateInstance<T>();
                FillInstance(ref entity);
                return entity;
            }

            public static void FillInstance<T>(ref T entity)
            {
                (entity as BaseEntity).DataHoraCadastro = DateTime.Now;
                (entity as BaseEntity).DataHoraAlteracao = DateTime.Now; ;
                (entity as BaseEntity).Status = (int)DefaultStatusEnum.Ativo;
            }
        }

    }
}