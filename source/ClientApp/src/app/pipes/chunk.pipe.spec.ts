import { ChunkPipe } from './chunk.pipe';

describe('ChunkPipe', () => {
  let pipe: ChunkPipe;

  beforeEach(() => {
    pipe = new ChunkPipe();
  });

  it('create an instance', () => {
    const pipe = new ChunkPipe();
    expect(pipe).toBeTruthy();
  });

  it('should split an array into chunks of a given size', () => {
    const array = [1, 2, 3, 4, 5];
    const chunkSize = 2;
    const result = pipe.transform(array, chunkSize);
    expect(result).toEqual([[1, 2], [3, 4], [5]]);
  });

  it('should handle an empty array', () => {
    const array: any[] = [];
    const chunkSize = 2;
    const result = pipe.transform(array, chunkSize);
    expect(result).toEqual([]);
  });

  it('should handle a null input', () => {
    const array: any[] | null = null;
    const chunkSize = 2;
    const result = pipe.transform(array, chunkSize);
    expect(result).toEqual([]);
  });

  it('should handle a zero chunk size', () => {
    const array = [1, 2, 3, 4, 5];
    const chunkSize = 0;
    const result = pipe.transform(array, chunkSize);
    expect(result).toEqual([]);
  });

  it('should handle a chunk size larger than the array length', () => {
    const array = [1, 2, 3, 4, 5];
    const chunkSize = 10;
    const result = pipe.transform(array, chunkSize);
    expect(result).toEqual([[1, 2, 3, 4, 5]]);
  });

  it('should handle a chunk size equal to the array length', () => {
    const array = [1, 2, 3, 4, 5];
    const chunkSize = 5;
    const result = pipe.transform(array, chunkSize);
    expect(result).toEqual([[1, 2, 3, 4, 5]]);
  });
});
