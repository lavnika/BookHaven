export interface Book {
  id: number;
  title: string;
  author: string;
  genre: string;
  available: boolean;
  distanceFromUser?: number;
}
