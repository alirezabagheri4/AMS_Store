﻿using Application.ViewModel.Enum;
using Domain.Aggregates.Product.@enum;
using Domain.Aggregates.Product.Models;

namespace Application.ViewModel
{
    public class ProductTitleViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ProductStateEnum ProductState { get; set; }

        public long Price { get; set; }
    }
}
