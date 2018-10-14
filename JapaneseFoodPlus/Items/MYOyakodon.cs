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
    public partial class MYOyakodonItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Oyakodon"; } }
        public override string Description                      { get { return "The bowl of rice topped with chicken and eggs binds the chicken which I boiled with mixed seasonings with a beaten egg and is kind of the bowl thing which I rode on a white meal. The name parent and child comes from that I use meat and the egg of the chicken."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 104, Fat = 15, Protein = 24, Vitamins = 7};
        public override float Calories                          { get { return 673; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MYGoldenProportionOfBoildSkill), 4)]    
    public partial class MYOyakodonRecipe : Recipe
    {
        public MYOyakodonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYOyakodonItem>(),
                new CraftingElement<GarbageItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 2, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(20), 
                new CraftingElement<PreparedMeatItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 30, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 10, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYEggItem>(typeof(MYGoldenProportionOfBoildEfficiencySkill), 5, MYGoldenProportionOfBoildEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYWoodenBowlItem>(1), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYOyakodonRecipe), Item.Get<MYOyakodonItem>().UILink(), 20, typeof(MYGoldenProportionOfBoildSpeedSkill)); 
            this.Initialize("Oyakodon", typeof(MYOyakodonRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}