function fishingBoat(input){

const priceForSpring=3000;
const priceForSummerAndAutumn=4200;
const priceForWinter=2600;

const budget=Number(input[0]);
const season=input[1];
const countOfFisherman=Number(input[2]);

let totalMoney=0;

switch(season){
    case "Winter": totalMoney = priceForWinter; break;
    case "Spring": totalMoney = priceForSpring; break;
    case "Autumn" :
    case "Summer" : totalMoney = priceForSummerAndAutumn; break;
}
if (countOfFisherman <= 6) {
    totalMoney -= totalMoney*0.10;
} else if(countOfFisherman >= 7 && countOfFisherman <= 11){
    totalMoney -= totalMoney*0.15;
} else if (countOfFisherman >= 12) {
    totalMoney -= totalMoney*0.25;
}

if (countOfFisherman % 2 === 0 && season != "Autumn") {
    totalMoney-=totalMoney*0.05;
}

if (budget >= totalMoney) {
    const moneyLeft=budget - totalMoney;
    console.log(`Yes! You have ${moneyLeft.toFixed(2)} leva left.`)
}
else    {
    const moneyNeeded= totalMoney - budget;
    console.log(`Not enough money! You need ${moneyNeeded.toFixed(2)} leva.`);
}
}
fishingBoat(["3000","Summer","11"]);
