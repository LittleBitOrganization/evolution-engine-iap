﻿using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.IAppModule.Commands.Factory;
using LittleBit.Modules.IAppModule.Data.Products;
using LittleBit.Modules.IAppModule.Layouts;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Purchasing;

namespace LittleBit.Modules.IAppModule.Data.Purchases
{
    [CreateAssetMenu(fileName = "Offer Config", menuName = "Configs/Store Configs/OfferConfig")]
    public class OfferConfig : ProductConfig
    {
        [SerializeField] private string id;
        [SerializeField] private ProductType productType = ProductType.Consumable;
        
        public string Id => id;
        public ProductType ProductType => productType;

        [SerializeField] private List<ProductConfig> products;
        [SerializeField] private IPurchaseInterfaceContainer layout;
        public IReadOnlyList<ProductConfig> Products => products;
        public IPurchaseInterfaceContainer Layout => layout;
        
        public override void HandlePurchase(PurchaseCommandFactory purchaseCommandFactory)
        {
            products.ForEach(x => x.HandlePurchase(purchaseCommandFactory));
        }

        [Button]
        private void ValidateId()
        {
            char[] chars = new char[] { '/','-','*' };
            id = chars.Aggregate(id, (c1, c2) => c1.Replace(c2, '_')).ToLower();
        }
    }
}