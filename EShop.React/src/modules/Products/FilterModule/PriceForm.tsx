import {Form, InputGroup} from "react-bootstrap";
import {useFormik} from "formik";

interface FilterModuleProps {
    onChange: (minPrice: string, maxPrice: string) => void
}

const PriceForm = (props: FilterModuleProps) => {

    const handleSubmit = (values: { minPrice: string, maxPrice: string }) => {
        props.onChange(values.minPrice, values.maxPrice)
    };

    const formik = useFormik({
        initialValues: {minPrice: '', maxPrice: ''},
        onSubmit: handleSubmit
    })

    return (
        <Form onChange={formik.handleSubmit}>
            <InputGroup>
                <Form.Control placeholder="От" name="minPrice" value={formik.values.minPrice}
                              onChange={formik.handleChange}
                              isInvalid={formik.touched.minPrice && !!formik.errors.minPrice}/>
                <InputGroup.Text>₽</InputGroup.Text>
                <Form.Control.Feedback type="invalid">{formik.errors.minPrice}</Form.Control.Feedback>
            </InputGroup>
            <InputGroup className="mt-2">
                <Form.Control placeholder="До" name="maxPrice" value={formik.values.maxPrice}
                              onChange={formik.handleChange}
                              isInvalid={formik.touched.maxPrice && !!formik.errors.maxPrice}/>
                <InputGroup.Text>₽</InputGroup.Text>
                <Form.Control.Feedback type="invalid">{formik.errors.maxPrice}</Form.Control.Feedback>
            </InputGroup>
        </Form>
    );
};

export default PriceForm;