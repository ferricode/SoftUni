//01. Hello SoftUni
function hello(){
    console.log("Hello SoftUni");
}
hello();

//02. Nums 1...10
function hello(){
    console.log(1);
    console.log(2);
    console.log(3);
    console.log(4);
    console.log(5);
    console.log(6);
    console.log(7);
    console.log(8);
    console.log(9);
    console.log(10);
}
hello();

//03. Square Area
function squareArea(input){
    console.log(Number(input)*Number(input));
}
squareArea(5);

//04. Inches to Centimeters
function converter(input){
        console.log(Number(input)*2.54);
    }
    converter(5);


//05. Greeting by Name
function greetings(input){
    let name=input[0];

    let greeting="Hello, " + name + "!";
    console.log(greeting);
}
greetings(['Feride']);

//06. Concatenate Data
function concatenateData(input){
    let firstName=input[0];
    let lastName=input[1];
    let age=Number(input[2]);
    let town=input[3];
    console.log("You are "+ firstName+" "+lastName+", a "+age+"-years old person from "+town+".")
}
concatenateData(["Feride", "Dzhebedzhi", 34, "Sofia"]);

//07. Projects Creation
function projectsCreation(input){
    let arcName=input[0];
    let projectsCount=Number(input[1]);
    let hours=input[1]*3;
    let result=`The architect ${arcName} will need ${hours} hours to complete ${projectsCount} project/s.`
    console.log(result)
}
projectsCreation(["Feride", 4]);

//"The architect {името на архитекта} will need {необходими часове} hours to complete {брой на проектите} project/s."

//08. Pet Shop

function petStore(input){
  let catFood=Number(input[1]);
  let dogFood=Number(input[0]);
    
  let dogFoodPrice=2.50;
  let catFoodPrice=4;
  let dogFoodPriceTotal=dogFood*dogFoodPrice;
  let catFoodPriceTotal=catFood*catFoodPrice;
  let totalPrice=dogFoodPriceTotal+catFoodPriceTotal;
    console.log(`${Number(totalPrice)} lv.`)
}
petStore(["5 ","4 "]);

//09. Yard Greening
function greeningYard(input){
    let price=7.61;
    let yards=Number(input[0]);
   // let discountPercentage=18;
      
    let discount=yards*price*0.18;
    let finalGreeningPrice=yards*price-discount;
    
      console.log(`The final price is: ${finalGreeningPrice} lv.`)
      console.log(`The discount is: ${discount} lv.`)
  }
  greeningYard(["150"])

  