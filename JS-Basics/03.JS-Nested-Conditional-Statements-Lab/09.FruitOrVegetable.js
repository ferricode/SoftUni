function fruitOrVegetable(input){
    const type=input[0]

    //tomato, cucumber, pepper и carrot
    switch (type){
        case "banana":
        case "apple":
        case "kiwi":
        case "cherry":
        case "lemon":
        case "grapes":console.log("fruit"); break;
        case "tomato":
        case "cucumber":
        case "pepper":
        case "carrot":
        case "grapes":console.log("vegetable"); break;
        default:console.log("unknown"); break;
    }
}
fruitOrVegetable(["tomato"]);