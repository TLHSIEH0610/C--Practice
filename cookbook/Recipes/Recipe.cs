
namespace cookbook.Recipes
{
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }
        public Recipe(IEnumerable<Ingredient> ingridents)
        {
            Ingredients = ingridents;
        }

    }

    public abstract class Ingredient
    {
        public abstract int Id { get; }

        public abstract string Name { get; }

        public virtual string PreparationInstructions => "add to other ingred";

    }
}