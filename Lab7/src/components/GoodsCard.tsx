import { ICard } from "./task2";

const GoodsCard = ({ imagePath, name, price }: ICard) => {
  return (
    <div className="d-flex justify-content-center flex-column">
      <img src={imagePath} alt={name} width="300" height="300" />
      <div className="text-center">
        <p className="fw-bold">{name}</p>
        <p>Cost: {price} UAH.</p>
      </div>
    </div>
  );
};

export default GoodsCard;