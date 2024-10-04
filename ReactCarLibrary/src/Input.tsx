export function Input(props: {
  isEditing: boolean;
  type: string;
  placeholder: string;
  name: string;
  required: boolean;
  pattern?: string;
  initialValue?: string;
}) {
  if (props.isEditing) {
    return (
      <input
        type={props.type}
        placeholder={props.placeholder}
        name={props.name}
        required={props.required}
        pattern={props.pattern}
        defaultValue={props.initialValue}
      />
    );
  }
  return <span> -- {props.initialValue} -- </span>;
}
