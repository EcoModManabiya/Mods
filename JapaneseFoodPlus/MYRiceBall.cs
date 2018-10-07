namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [Weight(150)]                                          
    public partial class MYRiceBallItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Rice Ball"; } }
        public override string Description                      { get { return "A rice ball is the food which I pressurize triangle, straw bag form, orbicularity, and molded rice."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 15, Fat = 0, Protein = 1, Vitamins = 0};
        public override float Calories                          { get { return 200; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 2)]    
    public partial class MYRiceBallRecipe : Recipe
    {
        public MYRiceBallRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYRiceBallItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(10),
                new CraftingElement<MYNoriItem>(1), 
                new CraftingElement<MYSaltedPlumItem>(1), 
                new CraftingElement<MYSaltItem>(typeof(HomeCookingEfficiencySkill), 5, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYRiceBallRecipe), Item.Get<MYRiceBallItem>().UILink(), 5, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Rice Ball", typeof(MYRiceBallRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}