import GoodsCard from "./GoodsCard";

export interface ICard {
  imagePath: string;
  name: string;
  price: number;
}

const cards: ICard[] = [
  {
    imagePath: "../images/cake.png",
    name: "Cake",
    price: 220,
  },
  {
    imagePath: "../images/candy.png",
    name: "Candy",
    price: 40,
  },
  {
    imagePath: "../images/apple.png",
    name: "Apple",
    price: 15,
  },
  {
    imagePath: "../images/milk.png",
    name: "Milk",
    price: 80,
  },
  {
    imagePath: "../images/gum.png",
    name: "Gum",
    price: 50,
  },
  {
    imagePath: "../images/pineapple.png",
    name: "Pineapple",
    price: 90,
  },
];

const Task2 = () => {
  return (
    <div className="d-flex flex-wrap align-items-center justify-content-center max-width">
      {cards.map((card) => (
        <GoodsCard {...card} />
      ))}
    </div>
  );
};

export default Task2;