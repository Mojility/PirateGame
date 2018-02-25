public class Goal {
    private readonly string _value;

    public Goal(string value) {
        _value = value;
    }

    public override bool Equals(object obj) {
        var goal = obj as Goal;
        return _value == goal._value;
    }
}