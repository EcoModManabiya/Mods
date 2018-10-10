namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    [Serialized]
    [RequiresSkill(typeof(ChefSkill), 0)]    
    public partial class TraditionalCookingSkill : Skill
    {
        public override string FriendlyName { get { return "Traditional Cooking"; } }
        public override string Description { get { return Localizer.DoStr(""); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class TraditionalCookingSkillBook : SkillBook<TraditionalCookingSkill, TraditionalCookingSkillScroll>
    {
        public override string FriendlyName { get { return "Traditional Cooking Skill Book"; } }
    }

    [Serialized]
    public partial class TraditionalCookingSkillScroll : SkillScroll<TraditionalCookingSkill, TraditionalCookingSkillBook>
    {
        public override string FriendlyName { get { return "Traditional Cooking Skill Scroll"; } }
    }

    [RequiresSkill(typeof(CookingSkill), 0)] 
    public partial class TraditionalCookingSkillBookRecipe : Recipe
    {
        public TraditionalCookingSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TraditionalCookingSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BasicSaladItem>(typeof(ResearchEfficiencySkill), 20, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FruitSaladItem>(typeof(ResearchEfficiencySkill), 20, ResearchEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = new ConstantValue(30);

            this.Initialize("Traditional Cooking Skill Book", typeof(TraditionalCookingSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
