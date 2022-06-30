export type Navbar = {
  name: string;
  link?: string;
  children?: Children[];
};

interface Children {
  name: string;
  link: string;
}

export type FormElement = {
  name: string;
  type: "number" | "text" | "datetime-local" | "checkbox" | "email" | "tel"| "time";
  id: string;
  selectOptions?: SelectOptions[];
  multiselect?: boolean;
};

export type SelectOptions = {
  id: number;
  label: string;
};

export type Instuctor = {
  id: number;
  name: string;
  surname: string;
  price: number;
  typeOfService: string;
  workHours: string;
};

export type Equipment = {
  id: number;
  type: string;
  name: string;
  price: number;
  active: boolean;
};

export type Trainers = {
  hasNextPage: boolean;
  hasPreviousPage: boolean;
  items: [Instuctor];
  pageNumber: number;
  totalCount: number;
  totalPages: number;
};

export type Equipments = {
  hasNextPage: boolean;
  hasPreviousPage: boolean;
  items: [Equipment];
  pageNumber: number;
  totalCount: number;
  totalPages: number;
};

export type Client = {
  id?: number;
  name: string;
  surname: string;
  email: string;
  idNo: string;
  pesel: string;
  phoneNumber: string;
};

export type Rental = {
  id: number;
  client: Client;
}

export type Timetable = {
  id: number;
  client: Client;
  trainer: Instuctor;
}


export type Timetables = {
  items: Timetable[]
}

export type Rentals = {
  items: Rental[]
}