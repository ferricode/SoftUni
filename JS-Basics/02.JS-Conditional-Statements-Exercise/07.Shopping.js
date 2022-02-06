function shopping(input){
//     •	Видеокарта – 250 лв./бр.
// •	Процесор – 35% от цената на закупените видеокарти/бр.
// •	Рам памет – 10% от цената на закупените видеокарти/бр.
const singleVideocardPrice=250;
const budget=Number(input[0]);
const videocardsCount=Number(input[1]);
const proccessorsCount=Number(input[2]); 
const ramCount=Number(input[3]); 

const videocardsPrice=videocardsCount*singleVideocardPrice;
const proccessorsPrice=videocardsPrice*0.35;
const ramPrice=videocardsPrice*0.1;

let totalSum=videocardsPrice+proccessorsPrice*proccessorsCount+ramPrice*ramCount;

if (videocardsCount>proccessorsCount) {
    totalSum*=0.85;
  }

  const difference=Math.abs(totalSum-budget).toFixed(2);
  if (totalSum<=budget) {
      console.log(`You have ${difference} leva left!`)
  }else{
      console.log(`Not enough money! You need ${difference} leva more!`)
  }

}

shopping(["900","2","1","3"]);