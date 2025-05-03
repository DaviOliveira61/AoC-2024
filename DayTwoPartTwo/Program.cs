var text = "";
using (var file = new StreamReader("./input.txt"))
{
    text = file.ReadToEnd();
}

bool IsSafe(List<int> report)
{
    if (report.Count < 2)
        return false;

    bool increasing = report[1] > report[0];
    bool decreasing = report[1] < report[0];

    if (!increasing && !decreasing)
        return false;

    for (int i = 1; i < report.Count; i++)
    {
        int diff = report[i] - report[i - 1];

        if (diff == 0 || Math.Abs(diff) > 3)
            return false;

        if (increasing && diff <= 0)
            return false;

        if (decreasing && diff >= 0)
            return false;
    }
    return true;
}

bool IsSafeNow(List<int> report)
{
    if (IsSafe(report))
        return true;

    for (int i = 0; i < report.Count; i++)
    {
        var removeSingleValue = new List<int>(report);
        removeSingleValue.RemoveAt(i);

        if (IsSafe(removeSingleValue))
            return true;
    }

    return false;
}
var lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

var safeCount = 0;

foreach (var line in lines)
{
    var report = new List<int>();
    foreach (var numberString in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
    {
        if (int.TryParse(numberString, out int num))
            report.Add(num);
    }

    if (IsSafeNow(report))
        safeCount++;
}

Console.WriteLine(safeCount);

