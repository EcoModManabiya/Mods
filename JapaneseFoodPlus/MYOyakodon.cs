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

        private static Nutrients nutrition = new Nutrients()    { Carbs = 110, Fat = 16, Protein = 28, Vitamins = 2};
        public override float Calories                          { get { return 1900; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 4)]    
    public partial class MYOyakodonRecipe : Recipe
    {
        public MYOyakodonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYOyakodonItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(20), 
                new CraftingElement<PreparedMeatItem>(typeof(HomeCookingEfficiencySkill), 30, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYSoySauceItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYEggItem>(typeof(HomeCookingEfficiencySkill), 5, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYOyakodonRecipe), Item.Get<MYOyakodonItem>().UILink(), 30, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Oyakodon", typeof(MYOyakodonRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}