﻿using BuisnessLogic.BindingModels;
using BuisnessLogic.StorageInterfaces;
using BuisnessLogic.ViewModels;
using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Implements
{
    public class RepairStorage:IRepairStorage
    {
        public List<RepairViewModel> GetFullList()
        {
            using var context = new StoDatabase();
            return context.Repairs
            .Select(CreateModel)
            .ToList();
        }
        public List<RepairViewModel> GetFilteredList(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new StoDatabase();
            return context.Repairs
            .Where(rec => rec.Name.Contains(model.Name))
            .Select(CreateModel)
            .ToList();
        }
        public RepairViewModel GetElement(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new StoDatabase();
            var repair = context.Repairs
            .FirstOrDefault(rec => rec.Name == model.Name || rec.Id
           == model.Id);
            return repair != null ? CreateModel(repair) : null;
        }
        public void Insert(RepairBindingModel model)
        {
            using var context = new StoDatabase();
            context.Repairs.Add(CreateModel(model, new Repair()));
            context.SaveChanges();
        }
        public void Update(RepairBindingModel model)
        {
            using var context = new StoDatabase();
            var element = context.Repairs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(RepairBindingModel model)
        {
            using var context = new StoDatabase();
            Repair element = context.Repairs.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Repairs.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Repair CreateModel(RepairBindingModel model, Repair
       repair)
        {
            repair.Name = model.Name;
            repair.WorkId = model.WorkId;
            repair.EmployeeId = (int)model.EmployeeId;
            repair.Status = model.Status;
            repair.Sum = model.Sum;
            repair.DateStart = model.DateStart;
            repair.DateEnd = model.DateEnd;
            return repair;
        }
        private static RepairViewModel CreateModel(Repair repair)
        {
            return new RepairViewModel
            {
            Name = repair.Name,
            WorkId = repair.WorkId,
            EmployeeId = (int)repair.EmployeeId,
            Status = repair.Status,
            Sum = repair.Sum,
            DateStart = repair.DateStart,
            DateEnd = repair.DateEnd
        };
        }
    }
}
