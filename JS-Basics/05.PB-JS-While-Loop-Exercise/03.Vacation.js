function vacation(input) {
  let excursionPrice = Number(input[0]);
  let money = Number(input[1]);
  let index = 2;
  let daysSpend = 0;
  let dayCounter = 0;
  while (money < excursionPrice) {
    let action = input[index];
    index++;
    let amountOfMoney = Number(input[index]);
    dayCounter++;
    switch (action) {
      case "spend":
        money -= amountOfMoney;
        if (money < 0) {
          money = 0;
        }
        daysSpend++;
        break;
      case "save":
        money += amountOfMoney;
        daysSpend = 0;
        break;
    }
    if (daysSpend >= 5) {
      console.log("You can't save the money.");
      console.log(`${dayCounter}`);
      break;
    }
    index++;
  }
  if (money >= excursionPrice) {
    console.log(`You saved the money for ${dayCounter} days.`);
  }
}
vacation([
  "110",
  "60",
  "spend",
  "10",
  "spend",
  "10",
  "spend",
  "10",
  "spend",
  "10",
  "spend",
  "10",
]);
