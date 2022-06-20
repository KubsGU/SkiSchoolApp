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
  type: "number" | "text" | "datetime-local" | "checkbox" | "email" | "tel";
  id: string;
  selectOptions?: SelectOptions[];
  multiselect?: boolean;
};

export type SelectOptions = {
  id: number;
  label: string;
}

export type Instuctor = {
  id: number;
  name: string;
  surname: string;
  price: number;
  service: string;
  workHours: string;
}

export type Equipment = {
  id: number;
  type: string;
  name: string;
  price: number;
  active: boolean;
}