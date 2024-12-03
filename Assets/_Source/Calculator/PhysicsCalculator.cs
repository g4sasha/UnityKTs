using ScriptableObjects;

public class PhysicsCalculator
{
    // E = MC^2
    public static double FormulaEnergyConnetction(EnergyConnectionFormulaSO formula)
    {
        return formula.Mass * (formula.C * formula.C);
    }
}
