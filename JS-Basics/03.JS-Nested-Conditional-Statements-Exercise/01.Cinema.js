function cinema(input) {
  const ticketType = input[0];
  const rows = Number(input[1]);
  const cols = Number(input[2]);

const premierPrice=12;
const normalPrice=7.5;
const discountePrice=5;

let totalMoney=0;

  switch (ticketType) {
      case "Premiere":totalMoney=rows*cols*premierPrice; break;
      case "Normal":totalMoney=rows*cols*normalPrice; break;
      case "Discount":totalMoney=rows*cols*discountePrice; break;
  }
  console.log(`${totalMoney.toFixed(2)} leva`);
}
cinema(["Normal","21","13"]);