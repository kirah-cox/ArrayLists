using ArrayLists;

public class UnitTest1
{
    private ArrayBasedList list = new ArrayBasedList(1);

    [Fact]
    public void CanMakeEmptyList()
    {
        var list = new ArrayBasedList();
        Assert.Equal(0, list.GetNumItems());
    }

    [Fact]
    public void GivenAnEmptyList_WhenIAddOne_ThereIsOne()
    {
        list.InsertValueAt(5, 0);
        Assert.Equal(1, list.GetNumItems());
    }

    [Fact]
    public void GivenAnEmptyList_WhenIAddOneAtTheFront_ItIsThere()
    {
        list.InsertValueAt(5, 0);
        Assert.Equal(5, list.GetValueAt(0));
    }

    [Fact]
    public void GivenAnEmptyList_WhenIAddPassedTheEnd_ItStillWorks()
    {
        list.InsertValueAt(5, 0);
        list.InsertValueAt(7, 1);
        Assert.Equal(7, list.GetValueAt(1));
    }

    [Fact]
    public void GivenAListWithValues_WhenIAddToTheFront_ItWorks()
    {
        list.InsertValueAt(5, 0);
        list.InsertValueAt(7, 0);
        Assert.Equal(5, list.GetValueAt(1));
        Assert.Equal(7, list.GetValueAt(0));
    }

    [Fact]
    public void GivenAListWithValues_ICanSetTheValueAtParticularIndex()
    {
        list.InsertValueAt(5, 0);
        list.SetValueAt(7, 0);
        Assert.Equal(7, list.GetValueAt(0));
    }

    [Fact]
    public void GivenAListWithValues_ICanRemoveTheValueAtParticularIndex()
    {
        list.InsertValueAt(5, 0);
        list.InsertValueAt(7, 1);
        list.RemoveValueAt(1);
        Assert.Equal(1, list.GetNumItems());
    }
}




