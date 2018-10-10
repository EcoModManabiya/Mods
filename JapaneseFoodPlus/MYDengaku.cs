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
    [Weight(100)]                                          
    public partial class MYDengakuItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Dengaku"; } }
        public override string Description                      { get { return "I spit tofu and konjac, eggplant or taro and apply the miso which I combine sugar and sweet sake and added a fragrance to in citron or a bud and am bakemeat."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 7, Fat = 1, Protein = 2, Vitamins = 1};
        public override float Calories                          { get { return 120; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 2)]    
    public partial class MYDengakuRecipe : Recipe
    {
        public MYDengakuRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MYDengakuItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MYTofuItem>(typeof(HomeCookingEfficiencySkill), 10, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<SugarItem>(typeof(HomeCookingEfficiencySkill), 5, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
                new CraftingElement<MYMisoItem>(typeof(HomeCookingEfficiencySkill), 5, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MYDengakuRecipe), Item.Get<MYDengakuItem>().UILink(), 20, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Dengaku", typeof(MYDengakuRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}