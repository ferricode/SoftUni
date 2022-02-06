function cake(input){
    let cakePiesces=Number(input[0])*Number(input[1]);
    let index=2;
    let command=Number(input[index]);
    let takenPieces=0;

    while(command!=="STOP"){
        takenPieces=Number(input[index]);
        if(cakePiesces-takenPieces>0 ){
            cakePiesces-=takenPieces;
        }
        else{
            break;
        }
      index++;
      command=input[index];
    }
    if(command==="STOP" && cakePiesces>0){
        console.log(`${cakePiesces} pieces are left.`)
    }else{
        console.log(`No more cake left! You need ${takenPieces-cakePiesces} pieces more.`)
    }

}
cake(["10",
"2",
"2",
"4",
"6",
"STOP"]);
