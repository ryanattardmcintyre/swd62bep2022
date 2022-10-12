﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Repositories;
using System.Linq;
namespace BusinessLogic.Services
{
    public class ItemsService
    {
        //the centralization of creation of instances implies a more efficient management of objects
        //i.e. we have to use a Design Pattern
        //Design Pattern : Dependency Injection - a variation of this is Constructor injection

        private ItemsRepository itemsRepository;
        public ItemsService(ItemsRepository _itemRepository)
        {
            itemsRepository = _itemRepository;
        }


        public void AddNewItem(string name, double price, int categoryId, int stock=0, string imagePath=null)
        {
            /*
             * foreach(Item x in GetItems())
             *  if (x.Name == name) {throw new .....}
             * 
             */


            if (itemsRepository.GetItems().Any(x=>x.Name==name))
                throw new Exception("Item with the same already exists");

            itemsRepository.AddItem(new Domain.Models.Item()
            {
                CategoryId = categoryId,
                ImagePath = imagePath,
                Name = name,
                Price = price,
                Stock = stock
            });
          
        }

        public void DeleteItem(int id)
        {
            
        }
       
    }
}